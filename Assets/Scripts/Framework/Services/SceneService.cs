using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Artifax.Framework
{
    public class SceneService : MonoBehaviour
    {
        
        private string m_CurrentScene = "";

        public string CurrentScene { get => m_CurrentScene; set => m_CurrentScene = value; }

        public Action<string> OnSceneLoaded;

        public void LoadScene(string newScene)
        {
            StartCoroutine(LoadSceneIntenral(newScene));
        }

        private IEnumerator LoadSceneIntenral(string newScene)
        {
            if (m_CurrentScene != string.Empty)
            {
                yield return SceneManager.UnloadSceneAsync(m_CurrentScene);
            }

            yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
            m_CurrentScene = newScene;

            OnSceneLoaded?.Invoke(newScene);
        }
    }
}
