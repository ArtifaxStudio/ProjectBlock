using Artifax.Framework;
using Artifax.ProjectBlock.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Artifax.ProjectBlock
{
    public class ApplicationLoader : MonoBehaviour
    {
        [Header("Services")]
        [SerializeField] private ServiceLocator m_ServiceLocator;

        [Header("Application")]
        [SerializeField, Scene]
        private string m_FirstScene;
        [SerializeField, Scene]
        private string m_CoreScene;

        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync(m_CoreScene, LoadSceneMode.Additive);

            yield return m_ServiceLocator.GetService<TransitionService>().StartTransition();

            var sceneService = m_ServiceLocator.GetService<SceneService>();
            sceneService.CurrentScene = this.gameObject.scene.name;
            sceneService.LoadScene(m_FirstScene);

            m_ServiceLocator.GetService<ProgressService>().LoadLevelData();
        }
    }
}
