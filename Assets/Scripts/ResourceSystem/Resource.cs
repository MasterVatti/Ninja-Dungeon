using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ResourceSystem
{
    /// <summary>
    /// Класс для работы с ресурсами
    /// </summary>
    [Serializable]
    public class Resource
    {

        [SerializeField]
        private ResourceType _type;
        [SerializeField]
        private float _amount;

        public ResourceType Type
        {
            get => _type;
            set => _type = value;
        }

        public float Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public static Resource GetResourceByType (List<Resource> resources, ResourceType type)
        {
            return (from resource in resources where resource.Type == type select resource).FirstOrDefault();

        }

        public static bool CompareResources (List<Resource> neededResources, List<Resource> availableResources)
        {
            foreach (var neededResource in neededResources)
            {
                if(GetResourceByType(availableResources, neededResource.Type).Amount < neededResource.Amount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
