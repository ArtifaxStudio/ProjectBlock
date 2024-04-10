using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu]
    public class IntVarible : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntVarible value)
        {
            Value = value.Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVarible amount)
        {
            Value += amount.Value;
        }
    }
}
