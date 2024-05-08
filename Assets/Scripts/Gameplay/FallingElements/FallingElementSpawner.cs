using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [RequireComponent(typeof(SimpleObjectPool))]
    public class FallingElementSpawner : MonoBehaviour
    {
        [SerializeField]
        private LevelConfiguration m_LevelConfiguration;
        [SerializeField]
        private SimpleObjectPool m_Pool;
        [SerializeField]
        private TransformReference m_Character;

        private System.Random m_RandomGenerator;

        private CharacterBlock m_CharacterBlock;

        private void Start()
        {
            m_CharacterBlock = m_Character.Value.GetComponent<CharacterBlock>();

            m_RandomGenerator = new System.Random(m_LevelConfiguration.Seed);
        }

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var spawnedObject = m_Pool.Get();
            spawnedObject.transform.position = GetRandomPosition();
            spawnedObject.GetComponent<FallingElement>().Initialize(GetRandomElement());
            spawnedObject.SetActive(true);
        }

        private Vector2 GetRandomPosition()
        {
            Vector2 normalizedPosition = new Vector2(Random.Range(0.1f, 0.9f), 1.1f);
            return Camera.main.ViewportToWorldPoint(normalizedPosition);
        }

        private FallingElementConfiguration GetRandomElement()
        {
            int index = m_RandomGenerator.Next(0, m_LevelConfiguration.FallingElements.Count);
            return m_LevelConfiguration.FallingElements[index];
        }
    }
}
