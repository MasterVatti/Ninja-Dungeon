using System;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
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

        public static bool CompareResources (List<Resource> neededResources, List<Resource> availableResources)
        {
            foreach (var neededResource in neededResources)
            {
                foreach (var availableResource in availableResources)
                {
                    if(availableResource.Amount < neededResource.Amount)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
