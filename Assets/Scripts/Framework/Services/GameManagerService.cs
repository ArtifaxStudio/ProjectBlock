using Artifax.ProjectBlock.Gameplay;
using UnityEngine;

namespace Artifax.ProjectBlock
{
    public class GameManagerService : MonoBehaviour
    {
        private LevelConfiguration m_NextLevel;

        public void SetLevel(LevelConfiguration nextLevel)
        {
            m_NextLevel = nextLevel; 
        }

        public LevelConfiguration GetNextLevelConfiguration() {  return m_NextLevel; }
    }
}
