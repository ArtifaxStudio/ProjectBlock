using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public abstract class FallingElement : MonoBehaviour
    {
        [SerializeField]
        private LayerMask m_BoundariesLayer;
        [SerializeField]
        private LayerMask m_PlayerLayer;

        [SerializeField]
        private TransformGameEvent m_OnBoundariesEvent;
        [SerializeField]
        private TransformGameEvent m_OnPlayerEvent;

        public abstract void Initialize();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(m_BoundariesLayer.LayersMatch(collision.gameObject.layer))
            {
                OnTouchBoundaries();
            }

            if(m_PlayerLayer.LayersMatch(collision.gameObject.layer))
            {
                OnTouchPlayer();
            }
        }

        protected virtual void OnTouchPlayer()
        {
            Destroy(gameObject);
            m_OnPlayerEvent.Raise(transform);
        }
        protected virtual void OnTouchBoundaries()
        {
            Destroy(gameObject);
            m_OnBoundariesEvent.Raise(transform);
        }
    }
}
