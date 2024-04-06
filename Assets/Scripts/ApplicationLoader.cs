using Artifax.Framework;
using System.Collections;
using UnityEngine;

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
            yield return m_ServiceLocator.GetService<TransitionService>().StartTransition();
            m_ServiceLocator.GetService<SceneService>().LoadScene(m_FirstScene);
        }
    }
}
