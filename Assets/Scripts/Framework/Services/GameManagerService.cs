using Artifax.ProjectBlock.Gameplay;

namespace Artifax.ProjectBlock.Framework
{
    public class GameManagerService : Service
    {
        private LevelConfiguration m_NextLevel;

        public void SetLevel(LevelConfiguration nextLevel)
        {
            m_NextLevel = nextLevel; 
        }

        public LevelConfiguration GetNextLevelConfiguration() {  return m_NextLevel; }
    }
}
