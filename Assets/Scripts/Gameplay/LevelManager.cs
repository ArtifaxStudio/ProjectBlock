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

        private void Awake()
        {
            GainedBlocks.Value = 0;
            LoosedBlocks.Value = 0;
        }

        public void OnPlayerTouched(FallingElement element)
        {
            if (element.Configuration.Color == CharacterBlock.Color)
            {
                GainedBlocks.Value++;
            }
            else
            {
                LoosedBlocks.Value++;
            }
        }

        public void OnBlockDestroyed(Transform transform)
        {
            LoosedBlocks.Value++;
        }
    }
}
