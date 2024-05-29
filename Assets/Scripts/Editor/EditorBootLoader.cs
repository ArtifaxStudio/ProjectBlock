using UnityEngine;
using UnityEngine.SceneManagement;

namespace Artifax.Framework
{
    public class EditorBootLoader
    {
        private const int CORE_SCENE_INDEX = 1;
        private const int BOOT_SCENE_INDEX = 0;
        private static string m_CurrentScene;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Start()
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(CORE_SCENE_INDEX) && 
                SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(BOOT_SCENE_INDEX))
            {
                m_CurrentScene = SceneManager.GetActiveScene().name;
                SceneManager.sceneLoaded += OnCoreSceneLoaded;
                SceneManager.LoadScene(CORE_SCENE_INDEX, LoadSceneMode.Additive);
            }
        }

        private static void OnCoreSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if(arg0 == SceneManager.GetSceneByBuildIndex(CORE_SCENE_INDEX))
            {
                GameObject.FindAnyObjectByType<SceneService>().CurrentScene = m_CurrentScene;
            }
        }
    }
}
