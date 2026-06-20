using System;

namespace SceneLoad
{
    public interface ISceneLoader
    {
        void LoadScene(SceneTypes scene, Action sceneLoaded);
    }
}