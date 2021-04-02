using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;
using UnityEngine.UI;


namespace Buildings
{
   public class ResourceMinerScreen : BaseScreenWithContext<BuildingContext>
   {
      [SerializeField] 
      private Text _buildingName;
      
      public override void ApplyContext(BuildingContext context)
      {
         _buildingName.text = context.BuildingName;
      }

      public override void Initialize(ScreenType screenType)
      {
         ScreenType = screenType;
      }
   }
}