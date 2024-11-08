using Artifax.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class CharacterBlockController : MonoBehaviour
    {
        [SerializeField]
        private TransformReference m_Character;
        [SerializeField]
        private LayerMask m_ColorBlockLayer;
        [SerializeField]
        private CharacterBlock m_BaseBlock;
        [SerializeField]
        private CharacterBlock m_PrefabBlock;

        private List<CharacterBlock> m_Blocks = new List<CharacterBlock>();

        public Color Color => m_Blocks[0].Color;

        private void Awake()
        {
            m_Character.Value = transform;
            m_Blocks.Add(m_BaseBlock);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!IsCollisionProcessable(collision.gameObject))
            {
                return;
            }

            var color = collision.gameObject.GetComponent<FallingElement>().SpriteRenderer.color;

            if (IsElementSameColor(color))
            {
                foreach (var cube in m_Blocks)
                {
                    cube.SetColor(color);
                }
            }
            else
            {
                AccumulateBlock();
            }
        }

        private void AccumulateBlock()
        {
            Debug.Log("Accumulate");
            var currentBlock = m_Blocks[m_Blocks.Count - 1];
            var go = Instantiate(m_PrefabBlock, new Vector3(currentBlock.transform.position.x, NextYBlockPosition(currentBlock), 0), Quaternion.identity, this.transform);
            m_Blocks.Add(go.GetComponent<CharacterBlock>());
        }

        private void RemoveBlock()
        {
            Debug.Log("Remove block");
        }

        private bool IsElementSameColor(Color color)
        {
            return Color == color;
        }

        private bool IsCollisionProcessable(GameObject otherObject)
        {
            return m_ColorBlockLayer.LayersMatch(otherObject.layer);
        }

        private float NextYBlockPosition(CharacterBlock block)
        {
            return block.transform.position.y + block.GetComponent<BoxCollider2D>().bounds.size.y; ;
        }
    }
}
