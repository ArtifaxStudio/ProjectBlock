using Artifax.Framework;
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
        [SerializeField]
        private string m_FirstScene;

        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            yield return m_ServiceLocator.GetService<TransitionService>().StartTransition();

            var sceneService = m_ServiceLocator.GetService<SceneService>();
            sceneService.CurrentScene = this.gameObject.scene.name;
            sceneService.LoadScene(m_FirstScene);
        }
    }
}
