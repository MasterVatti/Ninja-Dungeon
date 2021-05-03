using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за открытие скрина Барраков и инициализацю каждого конкретного поля союзника.
    /// </summary>
    public class BarracksScreen : BaseScreenWithContext<BuildingContext>
    {
        [SerializeField]
        private GameObject _barracksContent;
        [SerializeField]
        private GameObject _allyItem;

        private Barrack _barrack;

        private void Start()
        {
            foreach (var ally in _barrack.Allies)
            {
                CreateAndInitializeAllyItem(ally);
            }
        }

        public override void ApplyContext(BuildingContext context)
        {
            _barrack = context.Barrack;
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        private void CreateAndInitializeAllyItem(AlliesListSetting ally)
        {
            var rateObject = Instantiate(_allyItem, _barracksContent.transform);
            rateObject.GetComponent<AllyItemView>().Initialize(ally);
        }

        [UsedImplicitly]
        public void CloseScreen()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}