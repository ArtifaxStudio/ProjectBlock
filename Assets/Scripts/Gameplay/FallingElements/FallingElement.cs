using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class FallingElement : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        [SerializeField]
        private FallingElementConfiguration m_Config;

        [SerializeField]
        private LayerMask m_BoundariesLayer;
        [SerializeField]
        private LayerMask m_PlayerLayer;

        [SerializeField]
        private TransformGameEvent m_OnBoundariesEvent;
        [SerializeField]
        private BlockCollisionGameEvent m_OnPlayerEvent;
        [SerializeField]
        private GameObjectGameEvent m_OnUsed;

        public SpriteRenderer SpriteRenderer => m_SpriteRenderer;
        public FallingElementConfiguration Configuration => m_Config;

        public virtual void Initialize(FallingElementConfiguration configuration)
        {
            m_Config = configuration;

            m_SpriteRenderer.sprite = m_Config.Sprite;
            m_SpriteRenderer.color = m_Config.Color;
        }
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
            m_OnPlayerEvent.Raise(this);
            m_OnUsed.Raise(gameObject);
        }
        protected virtual void OnTouchBoundaries()
        {
            Destroy(gameObject);
            m_OnBoundariesEvent.Raise(transform);
            m_OnUsed.Raise(gameObject);
        }
    }
}
