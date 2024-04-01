using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameState State;

        public void OnPlayerTouched(Transform transform)
        {

        }

        public void OnBlockDestroyed(Transform transform)
        {
            State.DestroyedBlocks++;
        }
    }
}
