using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [RequireComponent(typeof(SimpleObjectPool))]
    public class FallingElementSpawner : MonoBehaviour
    {
        [SerializeField]
        private SimpleObjectPool m_Pool;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var spawnedObject = m_Pool.Get();
            spawnedObject.transform.position = GetRandomPosition();
            spawnedObject.SetActive(true);
        }

        private Vector2 GetRandomPosition()
        {
            Vector2 normalizedPosition = new Vector2(Random.Range(0.1f, 0.9f), 1.1f);
            return Camera.main.ViewportToWorldPoint(normalizedPosition);
        }   
    }
}
