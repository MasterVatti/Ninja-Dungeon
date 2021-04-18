using BuildingSystem;
using SaveSystem;

public class ShopBuilding : Building<DataShop>
{
    public override void OnUpgrade(DataShop oldBuildingState)
    {
        
    }

    public override DataShop GetState()
    {
        return new DataShop();
    }

    protected override void Initialize(DataShop data)
    {
       
    }
}
