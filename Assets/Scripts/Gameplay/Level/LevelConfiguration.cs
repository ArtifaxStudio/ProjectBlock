using System.Collections.Generic;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = PBScriptablePaths.GAMEPLAY_SCRIPTABLE_PATH + "LevelConfiguration")]
    public class LevelConfiguration : ScriptableObject
    {
        public int Seed = 123456;

        public int NeededBlocks = 30;
        public float BlockSpawnRatePerSecond = 1f;
        public AnimationCurve MultiplierCurveSpawnRatePerMinute = new AnimationCurve(new Keyframe[]{ new Keyframe(0f, 1f), new Keyframe(1f, 1f) });
        public float TimeDilatationCurveMultiplier = 1f;

        public List<ColorBlockConfiguration> FallingElements = new();
    }
}
