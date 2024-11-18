using Artifax.Framework;
using System.Collections;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
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
        [Header("Services")]
        [SerializeField] private ServiceLocator m_ServiceLocator;

        [SerializeField] private LevelConfiguration m_Configuration;
        private float m_NextSpawnT = 0f;
        private float m_CurrentSpawnRate = 0f;
        private float m_VariableSpawnRate = 1f;
        private float m_CurveSpawnRate = 1f;
        private float m_SpawnTime = 1f;
        private float m_InitialTime = 0f;

        private bool m_IsPlaying = false;


        private void Awake()
        {
            GainedBlocks.Value = 0;
            LoosedBlocks.Value = 0;
            DestroyedBlocks.Value = 0;

            State.Init();
            m_InitialTime = Time.time;
        }

        private void Start()
        {
            if (m_Configuration == null)
                m_Configuration = m_ServiceLocator.GetService<GameManagerService>().GetNextLevelConfiguration();

            m_CurveSpawnRate = m_Configuration.MultiplierCurveSpawnRatePerMinute.Evaluate(0);
            m_CurrentSpawnRate = CalculeSpawnRate();
            m_SpawnTime = 1f/m_CurrentSpawnRate;
            m_IsPlaying = true;
            StartCoroutine(ReCalculeCurveSpawnRate());
        }
        private IEnumerator ReCalculeCurveSpawnRate()
        {
            while (m_IsPlaying)
            {
                yield return new WaitForSeconds(1f);

                var mapValue = Remap(Time.time - m_InitialTime, 0f, 60f, 0f, 1f);
                m_CurveSpawnRate = m_Configuration.MultiplierCurveSpawnRatePerMinute.Evaluate(mapValue);
                m_CurrentSpawnRate = CalculeSpawnRate();
                m_SpawnTime = 1f / m_CurrentSpawnRate;
            }
        }

        public static float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
        }

        //TODO: Probably a Update isn't the best option
        private void Update()
        {
            if (m_NextSpawnT > Time.time)
                return;

            FallingElementSpawner.Spawn();

            //TODO: Spawner should control this??
            State.SpawnedElements++;

            m_NextSpawnT = Time.time + m_SpawnTime;
        }

        public void OnCharacterReachTop()
        {
            EndLevel();
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
                EndLevel();
            }
        }
        private void EndLevel()
        {
            m_EndLevelHud.SetActive(true);
        }
        private bool HasLevelEnd()
        {
            return GainedBlocks.Value == m_Configuration.NeededBlocks;
        }
        private float CalculeSpawnRate()
        {
            return m_Configuration.BlockSpawnRatePerSecond * m_VariableSpawnRate * m_CurveSpawnRate;
        }
    }
}
