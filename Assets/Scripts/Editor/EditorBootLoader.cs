using UnityEngine;
using UnityEngine.SceneManagement;

namespace Artifax.ProjectBlock.Editor
{
    public class EditorBootLoader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Start()
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
