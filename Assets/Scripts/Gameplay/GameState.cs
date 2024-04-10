using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName = "GameState", menuName = PBScriptablePaths.GAMEPLAY_SCRIPTABLE_PATH + "NewGameState")]
    public class GameState : ScriptableObject
    {
        public int LoosedBlocks { get; set; }
        public int AchievedBlocks { get; set; }
    }
}
