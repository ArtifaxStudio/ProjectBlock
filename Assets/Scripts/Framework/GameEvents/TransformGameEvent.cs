using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu(fileName = "NewTransfomGameEvent", menuName = GameEvent.SCRIPTABLE_PATH + "Transform Game Event")]
    public class TransformGameEvent : GameEvent<Transform> { }
}
