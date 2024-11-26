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
    [System.Serializable]
    public class GroupProgress
    {
        public int GroupID;
        public List<LevelProgress> LevelProgressList;
    }

    public class DataService : MonoBehaviour
    {
        private Dictionary<int, GroupProgress>  GroupsProgress = new Dictionary<int, GroupProgress>();

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
                Dictionary<int, GroupProgress> data = JsonConvert.DeserializeObject<Dictionary<int, GroupProgress>>(json);
                Debug.Log("Game Loaded!");
                GroupsProgress = data;
            }
            else
            {
                Debug.LogWarning("Save file not found!");
            }
        }

        [ContextMenu("Save levels data")]
        public void SaveLevelsData()
        {
            Save(GroupsProgress, "SaveData/save.json");
        }

        [ContextMenu("Delete levels file")]
        public void DeleteLevelsFile()
        {
            DeleteData("SaveData/save.json");
        }

        [ContextMenu("Delete levels data")]
        public void DeleteLevelsData()
        {
            GroupsProgress.Clear();
        }

        [ContextMenu("Populate levels data")]
        public void PopulateLevelsData()
        {
            GroupProgress groupProgress = new GroupProgress();
            LevelProgress levelProgress = new LevelProgress();

            levelProgress.Score = 0;
            levelProgress.LevelID = 0;
            levelProgress.Completed = true;

            groupProgress.LevelProgressList = new List<LevelProgress>();
            groupProgress.LevelProgressList.Add(levelProgress);

            if (!GroupsProgress.ContainsKey(0))
            {
                GroupsProgress.Add(0, groupProgress);
            }
        }

        [ContextMenu("Debug levels data")]
        public void DebugLevelsData()
        {
            foreach (var group in GroupsProgress)
            {
                Debug.Log("Group " + group.Value.GroupID);
                foreach (var level in group.Value.LevelProgressList)
                {
                    Debug.Log(level.LevelID + " Completed: " + level.Completed);
                }
            }
        }
#endif
    }
}
