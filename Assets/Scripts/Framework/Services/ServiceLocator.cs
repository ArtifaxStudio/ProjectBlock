using Artifax.ProjectBlock.Framework;
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

        public T GetService<T>() where T : Service
        {
            var type = typeof(T);
            if (!m_Services.TryGetValue(type, out var service))
            {
                throw new Exception($"Service {type} not found");
            }

            return (T)service;
        }

        public void RegisterService<T>(T service) where T : Service
        {
            var type = typeof(T);
            Assert.IsFalse(m_Services.ContainsKey(type),
                           $"Service {type} already registered");

            foreach ( var dependencie in service.ServiceDependencies)
            {
                if (!IsDependencieRegistered(dependencie.ServiceGUID))
                {
                    throw new Exception("Dependencie: " + dependencie.ServiceGUID + " not registered for the service: " + service.name);
                }
            }

            m_Services.Add(type, service);
        }

        public bool IsDependencieRegistered(GUID dependencieGuid)
        {
            foreach (var service in m_Services)
            {
                var serv = (Service)service.Value;
                if (serv.ServiceID == dependencieGuid) return true;
            }
            return false;
        }

        public void ClearServices()
        {
            m_Services.Clear();
        }
    }
}
