using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName = "NewBlockCollisionGameEvent", menuName = PBScriptablePaths.GAME_EVENT_SCRIPTABLE_PATH + "Block Collision Game Event")]
    public class BlockCollisionGameEvent : GameEvent<FallingElement> { }
}
