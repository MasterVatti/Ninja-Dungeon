using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;
/// <summary>
/// Класс, от которого наследуются все скрипты для зданий.
/// </summary>
public abstract class Building : MonoBehaviour
{
   public string BuildingName => _buildingName;
    
   [SerializeField]
   private string _buildingName;
   [SerializeField]
   private ScreenType _screenType;

   private void OnTriggerEnter(Collider other)
   {
      if (IsScreenAvailable())
      {
         var context = new BuildingContext()
         {
            BuildingName = _buildingName
         };
         MainManager.ScreenManager.OpenScreenWithContext(_screenType,context);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (IsScreenAvailable())
      {
         MainManager.ScreenManager.CloseAllScreens(); 
      }
   }

   private bool IsScreenAvailable()
   {
      return _screenType != ScreenType.None;
   }
}
