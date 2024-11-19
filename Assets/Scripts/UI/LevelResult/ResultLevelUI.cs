using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Artifax.ProjectBlock.UI
{
    public class ResultLevelUI : MonoBehaviour
    {
        [SerializeField] private Button m_ContinueButton;
        [SerializeField] private Button m_ReplayButton;
        [SerializeField] private TextMeshProUGUI m_TittleText;
        [SerializeField] private TextMeshProUGUI m_TimeText;
        [SerializeField] private TextMeshProUGUI m_LoosedBlocksText;

        public void SetResult(float time, int loosedBlocks, string result)
        {
            m_TittleText.text += result;
            m_TimeText.text += time;
            m_LoosedBlocksText.text += loosedBlocks;
        }
    }
}
