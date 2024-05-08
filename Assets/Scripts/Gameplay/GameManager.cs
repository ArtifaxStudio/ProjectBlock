using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator m_ServiceLocator;

        private void Start()
        {
            m_ServiceLocator.GetService<TransitionService>().EndTransition();
        }
    }
}
