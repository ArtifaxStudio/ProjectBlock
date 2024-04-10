using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public GameState State;
        //TODO: This should be getted by the ServiceLocator
        public CharacterBlock CharacterBlock;

        [SerializeField]
        private IntReference GainedBlocks;
        [SerializeField]
        private IntReference LoosedBlocks;

        public void OnPlayerTouched(FallingElement element)
        {
            if (element.Configuration.Color == CharacterBlock.Color)
            {
                GainedBlocks.Variable.SetValue(GainedBlocks.Value + 1);
            }
            else
            {
                LoosedBlocks.Variable.SetValue(LoosedBlocks.Value + 1);
            }
        }

        public void OnBlockDestroyed(Transform transform)
        {
            LoosedBlocks.Variable.SetValue(LoosedBlocks.Value + 1);
        }
    }
}
