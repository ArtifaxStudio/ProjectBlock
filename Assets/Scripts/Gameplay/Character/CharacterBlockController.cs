using Artifax.Framework;
using System;
using System.Collections.Generic;
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
        [SerializeField]
        private Transform m_BlocskHolder;
        [SerializeField]
        private BlockCollisionGameEvent m_OnFallingElementEvent;
        [SerializeField]
        private GameObjectGameEvent m_OnUsed;

        private List<CharacterBlock> m_Blocks = new List<CharacterBlock>();

        public Color Color => m_Blocks[0].Color;

        private void Awake()
        {
            m_Character.Value = transform;
            m_Blocks.Add(m_BaseBlock);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollide(collision);
        }

        public void OnCollide(Collision2D collision)
        {
            if (!IsCollisionProcessable(collision.gameObject))
            {
                return;
            }

            FallingElement element = collision.gameObject.GetComponent<FallingElement>();
            var color = element.SpriteRenderer.color;

            m_OnFallingElementEvent.Raise(element);

            if (!IsElementSameColor(color))
            {
                AccumulateBlock();
                foreach (var cube in m_Blocks)
                {
                    cube.SetColor(color);
                }
            }

            m_OnUsed.Raise(collision.gameObject);
        }

        private void Update()
        {
            for (int i = 1; i < m_Blocks.Count; i++)
            {
                var block = m_Blocks[i];
                FollowPreviousBlock(m_Blocks[i - 1].transform, m_Blocks[i].transform);
            }
        }

        private void FollowPreviousBlock(Transform characterBlock1, Transform characterBlock2)
        {
            if (characterBlock1.position.x != characterBlock2.position.x)
            {
                var diff = characterBlock1.position.x - characterBlock2.position.x;
                var value = characterBlock2.position.x + (diff/4f);

                characterBlock2.position = new Vector3(value, characterBlock2.position.y, characterBlock2.position.z);
            }
        }

        private void AccumulateBlock()
        {
            var currentBlock = m_Blocks[m_Blocks.Count - 1];
            var go = Instantiate(m_PrefabBlock, new Vector3(currentBlock.transform.position.x, NextYBlockPosition(currentBlock), 0), Quaternion.identity, m_BlocskHolder);
            var newBlock = go.GetComponent<CharacterBlock>();
            newBlock.OnCollide += OnCollide;
            m_Blocks.Add(newBlock);
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
