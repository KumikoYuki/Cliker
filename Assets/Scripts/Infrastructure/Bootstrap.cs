using SceneLoad;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ISceneLoader sceneLoader = new SceneLoader();
            
            sceneLoader.LoadScene(SceneTypes.Game, OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            Debug.Log("Scene Loaded");
        }
    }
}