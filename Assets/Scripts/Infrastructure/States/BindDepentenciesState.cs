using System;
using Infrastructure.StateMachine;
using SceneLoad;

namespace Infrastructure.States
{
    public class BindDepentenciesState : IEnterableState
    {
        private readonly ProjectContext _projectContext;
        
        public BindDepentenciesState(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void Enter()
        {
            BindClasses();
            BindStates();
            
            _projectContext.GameStateMachine.Enter<SceneLoadState, SceneTypes, Action>(SceneTypes.Game, OnSceneLoaded);
        }
        
        public void Exit() { }
        
        private void BindStates()
        {
            var state = new SceneLoadState(_projectContext.DependencyContainer.Resolve<ISceneLoader>());
            
                _projectContext.DependencyContainer.Register(state);
        }

        private void BindClasses()
        {
            var sceneLoader = new SceneLoader();
            
            _projectContext.DependencyContainer.Register<ISceneLoader>(sceneLoader);
        }
    }
}