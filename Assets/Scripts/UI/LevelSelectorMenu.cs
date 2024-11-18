using Artifax.Framework;
using Artifax.ProjectBlock.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Artifax.ProjectBlock
{
    public class LevelSelectorMenu : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator m_ServiceLocator;

        [SerializeField] private List<LevelConfiguration> m_Levels;
        [SerializeField] private GameObject m_LevelUIPrefab;
        [SerializeField] private RectTransform m_LevelsHolder;
        [SerializeField, Scene]
        private string m_GameplayScene;

        private void Start()
        {
            StartCoroutine(PrepareScene());
        }

        private void PopulateLevels()
        {
            //Prepare levels
            foreach (var level in m_Levels)
            {
                var go = Instantiate(m_LevelUIPrefab, m_LevelsHolder);
                if(go.TryGetComponent(out Button button))
                {
                    button.onClick.AddListener(()=> LoadLevel(level));
                }
            }
        }

        private void LoadLevel(LevelConfiguration configuration)
        {
            m_ServiceLocator.GetService<TransitionService>().StartTransition();
            m_ServiceLocator.GetService<GameManagerService>().SetLevel(configuration);
            m_ServiceLocator.GetService<SceneService>().LoadScene(m_GameplayScene);
        }

        private IEnumerator PrepareScene()
        {
            PopulateLevels();
            
            yield return m_ServiceLocator.GetService<TransitionService>().EndTransition();
        }
    }
}
