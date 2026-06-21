using System;
using SceneLoad;

namespace Infrastructure.States
{
    public sealed class SceneLoadState : IEnterableState<SceneTypes, Action>
    {
        private readonly ISceneLoader _sceneLoader;
    
         public SceneLoadState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(SceneTypes sceneType, Action onSceneLoaded)
        {
            _sceneLoader.LoadScene(sceneType, onSceneLoaded); 
        }
        
        public void Exit() { }
    }
}