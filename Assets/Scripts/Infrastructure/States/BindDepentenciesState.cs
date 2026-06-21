using System;
using Infrastructure.AddresablessProvider;
using Infrastructure.StateMachine;
using SceneLoad;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Infrastructure.States
{
    public class BindDepentenciesState : IEnterableState
    {
        private readonly ProjectContext _projectContext;
        
        private IDependencyContainer DiContainer => _projectContext.DependencyContainer;
        
        public BindDepentenciesState(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void Enter()
        {
            BindClasses();
            BindStates();
            
            _projectContext.GameStateMachine.Enter<ResourcesLoadState>();
        }

        public void Exit() { }
        
        private void BindClasses()
        {
            var sceneLoader = new SceneLoader();
            var addressablessProvider = new AddressablesProvider();
            
            DiContainer.Register<ISceneLoader>(sceneLoader);
            DiContainer.Register<IResourcesProvider>(addressablessProvider);
        }
        
        private void BindStates()
        {
            var sceneLoad = new SceneLoadState(DiContainer.Resolve<ISceneLoader>());
            var resoursesLoad = new ResourcesLoadState(_projectContext.GameRules, DiContainer.Resolve<IResourcesProvider>(), _projectContext.GameStateMachine);
            var preparation = new PreparationGameState(_projectContext.GameRules);
                
            DiContainer.Register(sceneLoad);
            DiContainer.Register(resoursesLoad);
            DiContainer.Register(preparation);
        }
    }
}