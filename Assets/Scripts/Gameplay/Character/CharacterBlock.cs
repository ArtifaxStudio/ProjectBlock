using System;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class CharacterBlock : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer m_Renderer;

        public Action<Collision2D> OnCollide;

        public Color Color => m_Renderer.color;

        public void SetColor(Color color)
        {
            m_Renderer.color = color;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollide?.Invoke(collision);
        }
    }
}
