using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator m_ServiceLocator;
        [SerializeField, Scene]
        private string m_MenuScene;

        private void Start()
        {
            m_ServiceLocator.GetService<TransitionService>().EndTransition();
        }

        public void BackToMenu()
        {
            m_ServiceLocator.GetService<TransitionService>().StartTransition();
            m_ServiceLocator.GetService<SceneService>().LoadScene(m_MenuScene);
        }
    }
}
