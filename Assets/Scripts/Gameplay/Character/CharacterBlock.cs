using Artifax.ProjectBlock.Gameplay;
using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artifax.ProjectBlock
{
    public class CharacterBlock : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer m_Renderer;

        public Color Color => m_Renderer.color;

        public void SetColor(Color color)
        {
            m_Renderer.color = color;
        }
    }
}
