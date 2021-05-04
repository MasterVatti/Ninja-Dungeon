using BuildingSystem;
using SaveSystem;

public class PortalBuilding : Building<PortalData>
{
    public override void OnUpgraded(PortalData oldBuildingState)
    {
        
    }

    public override PortalData GetState()
    {
        return new PortalData();
    }

    protected override void OnStateLoaded(PortalData data)
    {
    }
}
