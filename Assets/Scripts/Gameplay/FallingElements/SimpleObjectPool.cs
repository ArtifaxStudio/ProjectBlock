using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Artifax.ProjectBlock
{
    public class SimpleObjectPool : MonoBehaviour
    {
        [SerializeField]
        protected GameObject Prefab;
        [SerializeField]
        protected int InitialCount = 5;

        protected List<GameObject> m_Actives = new List<GameObject>();
        protected List<GameObject> m_Inactives = new List<GameObject>();

        protected void Start()
        {
            for (int i = 0; i < InitialCount; i++)
            {
                InstantiateNew();
            }
        }

        public void Release(GameObject instance)
        {
            m_Actives.Remove(instance);
            m_Inactives.Add(instance);

            instance.SetActive(false);
        }
        public GameObject Get()
        {
            if (m_Inactives.Count == 0)
                return GetNew();

            return GetInactive();
        }
        public void Clear()
        {
            foreach (GameObject obj in m_Actives)
            {
                Destroy(obj);
            }

            foreach (GameObject obj in m_Inactives)
            {
                Destroy(obj);
            }

            m_Actives.Clear();
            m_Inactives.Clear();
        }

        protected GameObject GetInactive()
        {
            GameObject instance = m_Inactives[0];

            m_Inactives.RemoveAt(0);
            m_Actives.Add(instance);

            return instance;
        }
        protected GameObject GetNew()
        {
            InstantiateNew();
            return GetInactive();
        }
        protected GameObject InstantiateNew()
        {
            GameObject instance = Instantiate(Prefab);
            m_Inactives.Add(instance);

            instance.SetActive(false);
            return instance;
        }
    }
}
