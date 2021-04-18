using BuildingSystem;
using SaveSystem;

public class PortalBuilding : Building<PortalData>
{
    public override void OnUpgrade(PortalData oldBuildingState)
    {
        
    }

    public override PortalData GetState()
    {
        return new PortalData();
    }

    protected override void Initialize(PortalData data)
    {
    }
}
