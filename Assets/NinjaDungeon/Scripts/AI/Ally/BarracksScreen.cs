using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using NinjaDungeon.Scripts.AI.Ally;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за  скрин Барраков и инициализацю каждого конкретного поля союзника.
    /// </summary>
    public class BarracksScreen : BaseScreenWithContext<BuildingContext>
    {
        [SerializeField]
        private GameObject _barracksContent;
        [SerializeField]
        private AllyItemView _allyItem;

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

        private void CreateAndInitializeAllyItem(AlliesSetting ally)
        {
            var allyItem = Instantiate(_allyItem, _barracksContent.transform);
            allyItem.Initialize(ally, _barrack);
        }

        [UsedImplicitly]
        public void CloseScreen()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}