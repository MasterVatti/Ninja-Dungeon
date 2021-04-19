using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;


namespace Barracks_and_allied_behavior
{
    public class BarracksScreen : BaseScreen
    {
        [SerializeField]
        private Barrack _barrack;
        [SerializeField]
        private GameObject _barracksContent;
        [SerializeField]
        private GameObject _allyItem;
        
        private void CreateAndInitializeAllyItem(Ally ally)
        {
            var rateObject = Instantiate(_allyItem, _barracksContent.transform);
            rateObject.GetComponent<AllyItemView>().Initialize(ally);
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
            foreach (var ally in _barrack.Allies)
            {
                CreateAndInitializeAllyItem(ally);
            }
        }

        [UsedImplicitly]
        private void CloseScreen()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}