using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock
{
    public class ServiceInstaller : MonoBehaviour
    {
        [Header("Services")]
        [SerializeField] private ServiceLocator m_ServiceLocator;

        private void Awake()
        {
            m_ServiceLocator.ClearServices();
            m_ServiceLocator.RegisterService(FindObjectOfType<SceneService>());
            m_ServiceLocator.RegisterService(FindObjectOfType<TransitionService>());
        }
    }
}
