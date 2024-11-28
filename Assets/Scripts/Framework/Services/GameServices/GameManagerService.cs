using Artifax.ProjectBlock.Gameplay;

namespace Artifax.ProjectBlock.Framework
{
    public class GameManagerService : Service
    {
        private LevelConfiguration m_NextLevel;
        private bool IsLevelReady;

        public void SetLevel(LevelConfiguration nextLevel)
        {
            m_NextLevel = nextLevel; 
            IsLevelReady = true;
        }

        public LevelConfiguration GetNextLevelConfiguration() 
        {
            IsLevelReady = false;
            return m_NextLevel; 
        }

        public bool IsNextLevelReady() { return IsLevelReady; }
    }
}
