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
            if (State.SpawnedElements >= Configuration.TotalFallingElements)
                return;

            if (m_NextSpawnT > Time.time)
                return;

            FallingElementSpawner.Spawn();

            float evaluator = (float)State.SpawnedElements / (float)Configuration.TotalFallingElements;
            float timeMultiplier = Configuration.TimeCurve.Evaluate(evaluator);
            float time = (timeMultiplier * Configuration.VariableTimeBetweenElements) + Configuration.BaseTimeBetweenElements;

            //TODO: Spawner should control this??
            State.SpawnedElements++;

            m_NextSpawnT = Time.time + time;
        }

        public void OnPlayerTouched(FallingElement element)
        {
            switch (element.Configuration)
            {
                case ColorBlockConfiguration:
                    ColorBlockTouchedPlayer(element);
                    break;
                default:
                    break;
            }
        }
        public void OnBlockDestroyed(FallingElement element)
        {
            switch (element.Configuration)
            {
                case ColorBlockConfiguration:
                    ColorBlockDestroyed(element);
                    break;
                default:
                    break;
            }
        }

        private void ColorBlockTouchedPlayer(FallingElement element)
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

        private void ColorBlockDestroyed(FallingElement element)
        {
            LoosedBlocks.Value++;
        }
    }
}
