using System;
using System.Collections.Generic;
using UnityEngine;

namespace Artifax.ProjectBlock.Framework
{
    [Serializable]
    public class ServiceDependencie
    {
        public string ServiceName;
        public GUID ServiceGUID;
    }

    public class Service : MonoBehaviour
    {
        public GUID ServiceID = new GUID(Guid.NewGuid().ToString());
        public List<ServiceDependencie> ServiceDependencies = new List<ServiceDependencie>();

        public virtual void Initialize() { }
    }
}
