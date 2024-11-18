using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class LooseBar : MonoBehaviour
    {
        [SerializeField]
        private LayerMask m_LayerMask;

        [SerializeField]
        private GameEvent m_OnCharacterReachTop;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            if ((m_LayerMask.LayersMatch(collision.gameObject.layer)))
            {
                m_OnCharacterReachTop.Raise();
            }
        }
    }
}
