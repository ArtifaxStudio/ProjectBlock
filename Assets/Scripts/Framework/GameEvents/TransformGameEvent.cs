using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu(fileName = "NewTransfomGameEvent", menuName = ArtifaxScriptablePaths.GAME_EVENT_SCRIPTABLE_PATH + "Transform Game Event")]
    public class TransformGameEvent : GameEvent<Transform> { }
}
