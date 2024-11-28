using Artifax.Framework;
using System.Collections.Generic;
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

    public class ProgressService : Service
    {
        public Dictionary<int, LevelProgress> LevelsProgress = new Dictionary<int, LevelProgress>();

        [SerializeField, ServiceLocatorReference] private ServiceLocator m_ServiceLocator;

        private DataService m_DataService;

        public LevelProgress GetLevelProgress(int levelID)
        {
            return LevelsProgress[levelID];
        }

        public void UpdateLevelProgress(int levelID, float time, int score)
        {
            if (!LevelsProgress.ContainsKey(levelID))
            {
                LevelProgress lp = new LevelProgress();

                LevelsProgress.Add(levelID, new LevelProgress(levelID, time, score));
            }
            else
            {
                var currentLevel = LevelsProgress[levelID];
                //TODO: Better time than before

            }

            m_ServiceLocator.GetService<ProgressService>().SaveLevelsData();
        }

#if UNITY_EDITOR
        private void Awake()
        {
            //LoadLevelData();
            m_DataService = m_ServiceLocator.GetService<DataService>();
            LevelsProgress = m_DataService.LoadData<Dictionary<int, LevelProgress>>("/SaveData" + "/save.json");
        }
#endif
#if UNITY_EDITOR
        [ContextMenu("Load levels data")]
        public void LoadLevelData()
        {
            LevelsProgress = m_DataService.LoadData<Dictionary<int, LevelProgress>>("/SaveData" + "/save.json");
        }

        [ContextMenu("Save levels data")]
        public void SaveLevelsData()
        {
            m_DataService.Save(LevelsProgress, "SaveData/save.json");
        }

        [ContextMenu("Delete levels file")]
        public void DeleteLevelsFile()
        {
            m_DataService.DeleteData("SaveData/save.json");
        }

        [ContextMenu("Delete levels data")]
        public void DeleteLevelsData()
        {
            LevelsProgress.Clear();
        }

        [ContextMenu("Populate levels data")]
        public void PopulateLevelsData()
        {
            LevelProgress levelProgress = new LevelProgress();

            levelProgress.Score = 0;
            levelProgress.LevelID = 0;
            levelProgress.Completed = true;

            if (!LevelsProgress.ContainsKey(0))
            {
                LevelsProgress.Add(0, levelProgress);
            }
        }

        [ContextMenu("Debug levels data")]
        public void DebugLevelsData()
        {
            foreach (var level in LevelsProgress)
            {
                Debug.Log(level.Value.LevelID + " Completed: " + level.Value.Completed);
            }
        }
#endif
    }
}
