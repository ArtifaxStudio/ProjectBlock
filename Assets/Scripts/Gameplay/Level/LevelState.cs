using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName = "LevelState", menuName = PBScriptablePaths.GAMEPLAY_SCRIPTABLE_PATH + "LevelState")]
    public class LevelState : ScriptableObject
    {
        public int SpawnedElements { get; set; } = 0;

        public void Init()
        {
            SpawnedElements = 0;
        }
    }
}
