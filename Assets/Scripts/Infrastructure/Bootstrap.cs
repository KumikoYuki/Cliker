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
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            var dependencyCountainer = new DependencyDictionaryContainer();
            var sceneFactory = new StateFactory(dependencyCountainer);
            var stateMachine = new GameStateMachine(sceneFactory);

            BindClasses(dependencyCountainer);
            BindStates(dependencyCountainer);
            
            stateMachine.Enter<SceneLoadState, SceneTypes, Action>(SceneTypes.Game, OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            Debug.Log("Scene loaded");
        }

        private void BindStates(DependencyDictionaryContainer dependencyCountainer)
        {
            var state = new SceneLoadState(dependencyCountainer.Resolve<ISceneLoader>());
            
            dependencyCountainer.Register(state);
        }

        private void BindClasses(DependencyDictionaryContainer dependencyCountainer)
        {
            var sceneLoader = new SceneLoader();
            
            dependencyCountainer.Register<ISceneLoader>(sceneLoader);
        }
    }
}