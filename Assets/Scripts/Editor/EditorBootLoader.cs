using UnityEngine;
using UnityEngine.SceneManagement;

namespace Artifax.ProjectBlock.Editor
{
    public class EditorBootLoader
    {
        private const int CORE_SCENE_INDEX = 0;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Start()
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(CORE_SCENE_INDEX))
            {
                SceneManager.LoadScene(CORE_SCENE_INDEX);
            }
        }
    }
}
