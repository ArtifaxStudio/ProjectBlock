using Artifax.ProjectBlock.Gameplay;
using TMPro;
using UnityEngine;

namespace Artifax.ProjectBlock.UI
{
    public class LevelGroupUI : MonoBehaviour
    {
        [SerializeField] private GameObject m_LevelPrefab;
        [SerializeField] private Transform m_LevelsHolder;
        [SerializeField] private TextMeshProUGUI m_LevelName;

        public void SetLevelGroup(string groupName)
        {
            m_LevelName.text = groupName;
        }

        public void AddLevel(LevelConfiguration configuration, LoadLevelDelegate loadLevelDelegate, bool state)
        {
            var go = Instantiate(m_LevelPrefab, m_LevelsHolder).GetComponent<LevelUI>();
            go.SetLevel(configuration, loadLevelDelegate, state);
        }
    }
}
