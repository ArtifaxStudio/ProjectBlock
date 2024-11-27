using Artifax.ProjectBlock.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Artifax.ProjectBlock.UI
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_LevelName;
        [SerializeField] private Button m_LevelButton;
        [SerializeField] private Image m_Completed;

        public void SetLevel(LevelConfiguration configuration, LoadLevelDelegate loadLevelDel, bool state)
        {
            m_LevelName.text = configuration.LevelName;
            m_LevelButton.onClick.AddListener( ()=> loadLevelDel(configuration));
            if (state)
            {
                m_Completed.color = Color.green;
            }
        }
    }
}
