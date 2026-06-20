using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneLoad
{
    public sealed class SceneLoader : ISceneLoader
    {
        public async void LoadScene(SceneTypes scene, Action sceneLoaded)
        {
          var operation = SceneManager.LoadSceneAsync((int)scene);

          while (operation.isDone == false)
          {
              await UniTask.Yield();
          }
          
          sceneLoaded?.Invoke();
        }
    }
}