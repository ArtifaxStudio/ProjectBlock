using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName = "GameState", menuName = "ProjectBlock/Gameplay/NewGameState")]
    public class GameState : ScriptableObject
    {
        public int DestroyedBlocks { get; set; }
    }
}
