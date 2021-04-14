using System.Linq;
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSaveConfig : ScriptableObject
    {
        public Save DefaultSave => new Save
        {
            Buildings = StartConstructions,
            Resources = StartResources
        };

        private Resource[] StartResources
        {
            get
            {
                return _startResources.Select(resource => new Resource
                {
                    Type = resource.Type,
                    Amount = resource.Amount
                }).ToArray();
            }
        }

        private BuildingData[] StartConstructions
        {
            get
            {
                return _startConstructions.Select(construction => new BuildingData
                {
                    IsBuilt = construction.IsBuilt,
                    SettingsID = construction.SettingsID,
                    State = ""
                }).ToArray();
            }
        }

        [SerializeField]
        private Resource[] _startResources;
        [SerializeField]
        private BuildingData[] _startConstructions;
    }
}
