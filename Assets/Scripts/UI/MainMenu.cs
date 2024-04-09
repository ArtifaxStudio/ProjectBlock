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
            Debug.Log("Preparing scene");
            StartCoroutine(PrepareScene());
        }

        public void LoadGameplay()
        {
            StartCoroutine(LoadGameplayInternal());  
        }

        private IEnumerator LoadGameplayInternal()
        {
            yield return m_ServiceLocator.GetService<TransitionService>().StartTransition();
            m_ServiceLocator.GetService<SceneService>().LoadScene(m_GameplayScene);
        }

        private IEnumerator PrepareScene()
        {
            yield return m_ServiceLocator.GetService<TransitionService>().EndTransition();

            Debug.Log("Ending transition");
        }
    }
}
