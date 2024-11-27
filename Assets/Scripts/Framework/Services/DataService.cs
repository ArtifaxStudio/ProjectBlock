using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


namespace Artifax.ProjectBlock.Framework
{

    public class DataService : MonoBehaviour
    {
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
            string filePath =  Path.Combine(Application.dataPath, fileName);
            if (FileExists(filePath))
            {
                string json = File.ReadAllText(filePath);
                T data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
            else
            {
                Debug.LogWarning("Save file not found!");
                return default(T);
            }
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
    }
}
