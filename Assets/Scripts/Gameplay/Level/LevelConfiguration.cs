using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = PBScriptablePaths.GAMEPLAY_SCRIPTABLE_PATH + "LevelConfiguration")]
    public class LevelConfiguration : ScriptableObject
    {
        public int TotalFallingElements = 50;
        public float BaseTimeBetweenElements = 1f;
        public AnimationCurve TimeCurve = new AnimationCurve(new Keyframe[]{ new Keyframe(0f, 1f), new Keyframe(1f, 1f) });
    }
}
