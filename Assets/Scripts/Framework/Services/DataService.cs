using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
    }

    public class DataService : MonoBehaviour
    {
        public Dictionary<int, LevelProgress> LevelsProgress = new Dictionary<int, LevelProgress>();

        private void Awake()
        {
            LoadLevelData();
        }

        public void Save<T>(T data, string fileName)
        {
#if UNITY_EDITOR
            string dataJson = JsonConvert.SerializeObject(data);
            var path = Path.Combine(Application.dataPath, fileName);
            File.WriteAllText(path, dataJson);
#else
            string dataJson = JsonConvert.SerializeObject(data);
            var path = Path.Combine(Application.persistentDataPath, fileName);
            File.WriteAllText(path, dataJson);
#endif
        }

        public T LoadData<T>(string fileName)
        {
            return default(T);
        }

        public bool FileExists(string fileName)
        {
#if UNITY_EDITOR
            var dataPath = Path.Combine(Application.dataPath, fileName);
#else
            var dataPath = Path.Combine(Application.persistentDataPath, fileName);
#endif

            return File.Exists(dataPath);
        }

        public void DeleteData(string fileName)
        {
#if UNITY_EDITOR
            var filePath = Path.Combine(Application.dataPath, fileName);
#else
            var filePath = Path.Combine(Application.persistentDataPath, fileName);
#endif
            if (FileExists(filePath))
            {
                File.Delete(filePath);
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Load levels data")]
        public void LoadLevelData()
        {
            string path = Application.dataPath + "/SaveData" + "/save.json";
            if (FileExists("SaveData/save.json"))
            {
                string json = File.ReadAllText(path);
                Dictionary<int, LevelProgress> data = JsonConvert.DeserializeObject<Dictionary<int, LevelProgress>>(json);
                Debug.Log("Game Loaded!");
                LevelsProgress = data;
            }
            else
            {
                Debug.LogWarning("Save file not found!");
            }
        }

        [ContextMenu("Save levels data")]
        public void SaveLevelsData()
        {
            Save(LevelsProgress, "SaveData/save.json");
        }

        [ContextMenu("Delete levels file")]
        public void DeleteLevelsFile()
        {
            DeleteData("SaveData/save.json");
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
