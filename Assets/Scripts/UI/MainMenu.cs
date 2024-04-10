using Artifax.Framework;
using System.Collections;
using UnityEngine;

namespace Artifax.ProjectBlock
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator m_ServiceLocator;

        [SerializeField]
        private string m_GameplayScene;

        private void Start()
        {
            StartCoroutine(PrepareScene());
        }

        public void LoadGameplay()
        {
            StartCoroutine(LoadGameplay_Coroutine());  
        }

        private IEnumerator LoadGameplay_Coroutine()
        {
            yield return m_ServiceLocator.GetService<TransitionService>().StartTransition();
            m_ServiceLocator.GetService<SceneService>().LoadScene(m_GameplayScene);
        }

        private IEnumerator PrepareScene()
        {
            yield return m_ServiceLocator.GetService<TransitionService>().EndTransition();
        }
    }
}
