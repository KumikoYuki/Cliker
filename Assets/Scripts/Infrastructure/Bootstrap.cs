using System;
using Infrastructure.StateMachine;
using Infrastructure.States;
using SceneLoad;
using UnityEngine;
using GameStateMachine = Infrastructure.StateMachine.StateMachine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private ProjectContext _projectContext;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            var dependencyCountainer = new DependencyDictionaryContainer();
            var sceneFactory = new StateFactory(dependencyCountainer);
            var stateMachine = new GameStateMachine(sceneFactory);
            _projectContext = new ProjectContext(dependencyCountainer, stateMachine);

            dependencyCountainer.Register(new Load);
            
            BindClasses(dependencyCountainer);
            BindStates(dependencyCountainer);
            
            stateMachine.Enter<SceneLoadState, SceneTypes, Action>(SceneTypes.Game, OnSceneLoaded);
        }

        private void Update()
        {
            _projectContext.GameStateMachine.Tick();
        }

        private void OnSceneLoaded()
        {
            Debug.Log("Scene loaded");
        }

        
    }
}