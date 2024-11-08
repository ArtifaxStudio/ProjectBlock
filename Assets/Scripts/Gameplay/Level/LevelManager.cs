using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public LevelConfiguration Configuration;
        public LevelState State;

        //TODO: This should be a TransformVariable
        public CharacterBlockController CharacterBlock;

        [SerializeField]
        private FallingElementSpawner FallingElementSpawner;

        [SerializeField]
        private GameObject m_EndLevelHud;

        [Header("Scriptable References")]
        [SerializeField]
        private IntReference GainedBlocks;
        [SerializeField]
        private IntReference LoosedBlocks;
        [SerializeField]
        private IntReference DestroyedBlocks;

        private float m_NextSpawnT = 0f;

        private void Awake()
        {
            GainedBlocks.Value = 0;
            LoosedBlocks.Value = 0;
            DestroyedBlocks.Value = 0;

            State.Init();
        }

        //TODO: Probably a Update isn't the best option
        private void Update()
        {
            if (m_NextSpawnT > Time.time)
                return;

            FallingElementSpawner.Spawn();

            //TODO: Redo timing
            float evaluator = (float)State.SpawnedElements / 100;
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

            DestroyedBlocks.Value++;

            TryEndLevel();
        }

        private void ColorBlockDestroyed(FallingElement element)
        {
            LoosedBlocks.Value++;
            DestroyedBlocks.Value++;

            TryEndLevel();
        }
        private void TryEndLevel()
        {
            if (HasLevelEnd())
            {
                Debug.Log("Level end");
                m_EndLevelHud.SetActive(true);
            }
        }
        private bool HasLevelEnd()
        {
            return GainedBlocks.Value == Configuration.NeededBlocks;
        }
    }
}
