using Artifax.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Artifax.ProjectBlock.Framework
{
    [System.Serializable]
    public class LevelProgress
    {
        public int LevelID;
        public bool Completed;
        public int Score;
        public float Time;

        public LevelProgress() { }
        public LevelProgress(int levelID, float time, int score)
        {
            LevelID = levelID;
            Completed = true;
            Time = time;
            Score = score;
        }
    }
    [System.Serializable]
    public class CoreGameProgress
    {
        public Dictionary<int, LevelProgress> LevelsProgress = new Dictionary<int, LevelProgress>();
        public CoreGameProgress() {
            LevelsProgress = new Dictionary<int, LevelProgress>();
        }

        public readonly string FILE_PATH = "/SaveData/save.json";
    }

    public class ProgressService : Service
    {
        public CoreGameProgress CoreGameProgress;

        [SerializeField, ServiceLocatorReference] private ServiceLocator m_ServiceLocator;

        private DataService m_DataService;

        public LevelProgress GetLevelProgress(int levelID)
        {
            if(CoreGameProgress.LevelsProgress.ContainsKey(levelID) ) 
                return CoreGameProgress.LevelsProgress[levelID];
            else 
                return null;
        }

        public void UpdateLevelProgress(int levelID, float time, int score)
        {
            if (!CoreGameProgress.LevelsProgress.ContainsKey(levelID))
            {
                LevelProgress lp = new LevelProgress();

                CoreGameProgress.LevelsProgress.Add(levelID, new LevelProgress(levelID, time, score));
            }
            else
            {
                var currentLevel = CoreGameProgress.LevelsProgress[levelID];
                //TODO: Better time than before

            }

            m_ServiceLocator.GetService<ProgressService>().SaveLevelsData();
        }

#if UNITY_EDITOR
        private void Awake()
        {
            m_DataService = m_ServiceLocator.GetService<DataService>();

            if(m_DataService.FileExists(CoreGameProgress.FILE_PATH))
                CoreGameProgress = m_DataService.LoadData<CoreGameProgress>(CoreGameProgress.FILE_PATH);
        }

        [ContextMenu("Load levels data")]
        public void LoadLevelData()
        {
            CoreGameProgress.LevelsProgress = m_DataService.LoadData<Dictionary<int, LevelProgress>>(CoreGameProgress.FILE_PATH);
        }

        [ContextMenu("Save levels data")]
        public void SaveLevelsData()
        {
            m_DataService.Save(CoreGameProgress.LevelsProgress, CoreGameProgress.FILE_PATH);
        }

        [ContextMenu("Delete levels file")]
        public void DeleteLevelsFile()
        {
            m_DataService.DeleteData(CoreGameProgress.FILE_PATH);
        }

        [ContextMenu("Delete levels data")]
        public void DeleteLevelsData()
        {
            CoreGameProgress.LevelsProgress.Clear();
        }

        [ContextMenu("Populate levels data")]
        public void PopulateLevelsData()
        {
            LevelProgress levelProgress = new LevelProgress();

            levelProgress.Score = 0;
            levelProgress.LevelID = 0;
            levelProgress.Completed = true;

            if (!CoreGameProgress.LevelsProgress.ContainsKey(0))
            {
                CoreGameProgress.LevelsProgress.Add(0, levelProgress);
            }
        }

        [ContextMenu("Debug levels data")]
        public void DebugLevelsData()
        {
            foreach (var level in CoreGameProgress.LevelsProgress)
            {
                Debug.Log(level.Value.LevelID + " Completed: " + level.Value.Completed);
            }
        }
#endif
    }
}
