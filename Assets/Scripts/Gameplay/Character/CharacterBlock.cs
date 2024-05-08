using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class CharacterBlock : MonoBehaviour
    {
        [SerializeField]
        private TransformReference m_Character;
        [SerializeField]
        private LayerMask m_ColorBlockLayer;
        [SerializeField]
        private SpriteRenderer m_Renderer;

        public Color Color => m_Renderer.color;

        private void Awake()
        {
            m_Character.Value = transform;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(m_ColorBlockLayer.LayersMatch(collision.gameObject.layer))
            {
                m_Renderer.color = collision.gameObject.GetComponent<FallingElement>().SpriteRenderer.color;
            }
        }
    }
}
