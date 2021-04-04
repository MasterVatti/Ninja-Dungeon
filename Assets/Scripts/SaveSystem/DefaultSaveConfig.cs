using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSaveConfig : ScriptableObject
    {
        public Save DefaultSave => new Save
        {
            Buildings = new List<BuildingData>(_startConstructions).ToArray(),
            Resources = new List<Resource>(_startResources).ToArray()
        };

        [SerializeField]
        private List<Resource> _startResources;
        [SerializeField]
        private List<BuildingData> _startConstructions;
    }
}
