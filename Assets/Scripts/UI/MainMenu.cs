using Artifax.Framework;
using System.Collections;
using System.Collections.Generic;
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
            StartCoroutine(m_ServiceLocator.GetService<TransitionService>().EndTransition());
        }

        public void LoadGameplay()
        {
            m_ServiceLocator.GetService<SceneService>().LoadScene(m_GameplayScene);
        }
    }
}
