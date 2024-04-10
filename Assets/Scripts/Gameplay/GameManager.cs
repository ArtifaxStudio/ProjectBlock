using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameState State;

        [SerializeField]
        private ServiceLocator m_ServiceLocator;

        private void Start()
        {
            m_ServiceLocator.GetService<TransitionService>().EndTransition();
        }

        public void OnPlayerTouched(Transform transform)
        {

        }

        public void OnBlockDestroyed(Transform transform)
        {
            State.DestroyedBlocks++;
        }
    }
}
