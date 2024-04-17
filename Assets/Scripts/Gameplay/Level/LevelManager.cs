using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public LevelConfiguration Configuration;
        public LevelState State;

        //TODO: This should be a TransformVariable
        public CharacterBlock CharacterBlock;

        [SerializeField]
        private FallingElementSpawner FallingElementSpawner;

        [Header("Scriptable References")]
        [SerializeField]
        private IntReference GainedBlocks;
        [SerializeField]
        private IntReference LoosedBlocks;

        private void Awake()
        {
            GainedBlocks.Value = 0;
            LoosedBlocks.Value = 0;

            State.Init();
        }

        private float m_NextSpawnT = 0f;

        //TODO: Probably a Update isn't the best option
        private void Update()
        {
            if (State.SpawnedElements > Configuration.TotalFallingElements)
                return;

            if (m_NextSpawnT > Time.time)
                return;

            FallingElementSpawner.Spawn();

            float evaluator = State.SpawnedElements / Configuration.TotalFallingElements;
            float timeMultiplier = Configuration.TimeCurve.Evaluate(evaluator);
            float time = timeMultiplier * Configuration.BaseTimeBetweenElements;

            //TODO: Spawner should control this??
            State.SpawnedElements++;

            m_NextSpawnT = Time.time + time;
        }

        public void OnPlayerTouched(FallingElement element)
        {
            if (element.Configuration.Color == CharacterBlock.Color)
            {
                GainedBlocks.Value++;
            }
            else
            {
                LoosedBlocks.Value++;
            }
        }
        public void OnBlockDestroyed(Transform transform)
        {
            LoosedBlocks.Value++;
        }
    }
}
