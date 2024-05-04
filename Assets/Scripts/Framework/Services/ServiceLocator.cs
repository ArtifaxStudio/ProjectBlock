using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Artifax.Framework
{
    [CreateAssetMenu(fileName = "ServiceLocator", menuName = "Artifax/Service Locator")]
    public class ServiceLocator : ScriptableObject
    {
        private readonly Dictionary<Type, object> m_Services = new Dictionary<Type, object> ();

        public Dictionary<Type, object> Services { get { return m_Services; } }

        public T GetService<T>()
        {
            var type = typeof(T);
            if (!m_Services.TryGetValue(type, out var service))
            {
                throw new Exception($"Service {type} not found");
            }

            return (T)service;
        }

        public void RegisterService<T>(T service)
        {
            var type = typeof(T);
            Assert.IsFalse(m_Services.ContainsKey(type),
                           $"Service {type} already registered");

            m_Services.Add(type, service);
        }

        public void ClearServices()
        {
            m_Services.Clear();
        }
    }
}
