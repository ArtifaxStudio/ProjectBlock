using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu(fileName = "NewGameObjectGameEvent", menuName = ArtifaxScriptablePaths.GAME_EVENT_SCRIPTABLE_PATH + "GameObject Game Event")]
    public class GameObjectGameEvent : GameEvent<GameObject> { }
}
