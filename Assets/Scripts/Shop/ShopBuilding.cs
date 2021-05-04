using BuildingSystem;
using SaveSystem;

public class ShopBuilding : Building<DataShop>
{
    public override void OnUpgraded(DataShop oldBuildingState)
    {
        
    }

    public override DataShop GetState()
    {
        return new DataShop();
    }

    protected override void OnStateLoaded(DataShop data)
    {
       
    }
}
