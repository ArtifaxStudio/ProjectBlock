using Artifax.Framework;
using Artifax.ProjectBlock.Framework;
using Artifax.ProjectBlock.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Artifax.ProjectBlock.UI
{
    public delegate void LoadLevelDelegate(LevelConfiguration config);
    public class LevelSelectorMenu : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator m_ServiceLocator;

        [SerializeField] private List<LevelsGroup> m_LevelGroups;
        [SerializeField] private GameObject m_LevelsGroupUIPrefab;
        [SerializeField] private RectTransform m_LevelsHolder;

        private void Start()
        {
            StartCoroutine(PrepareScene());
        }

        private void PopulateLevelSelector()
        {
            foreach (var levelGroup in m_LevelGroups)
            {
                var group = Instantiate(m_LevelsGroupUIPrefab, m_LevelsHolder).GetComponent<LevelGroupUI>();
                group.SetLevelGroup(levelGroup.GroupName);

                var progressService = m_ServiceLocator.GetService<ProgressService>();

                foreach (var levelConfiguration in levelGroup.Levels)
                {
                    var state = false;
                    var levelProgress = progressService.GetLevelProgress(levelConfiguration.ID);
                    if (levelProgress != null)
                    {
                        state = levelProgress.Completed;
                    }

                    group.AddLevel(levelConfiguration, LoadLevel, state);
                }
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(m_LevelsHolder);
        }

        private void LoadLevel(LevelConfiguration configuration)
        {
            m_ServiceLocator.GetService<TransitionService>().StartTransition();
            m_ServiceLocator.GetService<GameManagerService>().SetLevel(configuration);
            m_ServiceLocator.GetService<SceneService>().LoadScene(configuration.BaseLevelScene);
        }

        private IEnumerator PrepareScene()
        {
            PopulateLevelSelector();
            
            yield return m_ServiceLocator.GetService<TransitionService>().EndTransition();
        }
    }
}
