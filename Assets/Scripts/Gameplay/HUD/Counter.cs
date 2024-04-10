using Artifax.Framework;
using TMPro;
using UnityEngine;

namespace Artifax.ProjectBlock.GUI
{
    public class Counter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_CountText;

        [SerializeField]
        private IntReference m_Reference;

        private void OnEnable()
        {
            m_Reference.OnReferenceUpdate += UpdateCount;
        }

        private void OnDisable()
        {
            m_Reference.OnReferenceUpdate -= UpdateCount;
        }

        private void UpdateCount()
        {
            m_CountText.text = m_Reference.ToString();
        }
    }
}
