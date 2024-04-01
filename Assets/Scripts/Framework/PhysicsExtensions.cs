using UnityEngine;

namespace Artifax.Framework
{
    public static class PhysicsExtensions
    {
        public static bool LayersMatch(this LayerMask layers, int other)
        {
            return 0 != (layers.value & 1 << other);
        }
    }
}
