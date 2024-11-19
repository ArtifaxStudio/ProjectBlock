using Artifax.ProjectBlock.Gameplay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Artifax.ProjectBlock.UI
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_LevelName;
        [SerializeField] private Button m_LevelButton;

        public void SetLevel(LevelConfiguration configuration, LoadLevelDelegate loadLevelDel)
        {
            m_LevelName.text = configuration.LevelName;
            m_LevelButton.onClick.AddListener( ()=> loadLevelDel(configuration));
        }
    }
}
