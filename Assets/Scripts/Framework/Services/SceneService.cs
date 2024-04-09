using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
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
            StartCoroutine(LoadScene_Coroutine(newScene));
        }

        private IEnumerator LoadScene_Coroutine(string newScene)
        {
            if (m_CurrentScene != string.Empty)
            {
                SceneManager.SetActiveScene(this.gameObject.scene);
                yield return SceneManager.UnloadSceneAsync(m_CurrentScene);
            }

            yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);

            var scene = SceneManager.GetSceneByName(newScene);
            Assert.IsTrue(SceneManager.SetActiveScene(scene));


            OnSceneLoaded?.Invoke(newScene);
            m_CurrentScene = newScene;
        }
    }
}
