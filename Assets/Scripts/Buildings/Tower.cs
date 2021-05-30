using BuildingSystem;
using SaveSystem;
using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(ProjectileLauncher.ProjectileLauncher))]
    public class Tower : UpgradableBuilding<BaseBuildingState>
    {
        public override BaseBuildingState GetState()
        {
            return new BaseBuildingState();
        }
        
        protected override void OnStateLoaded(BaseBuildingState data)
        {
            
        }
    }
}
