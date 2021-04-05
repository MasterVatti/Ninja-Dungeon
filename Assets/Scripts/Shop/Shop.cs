using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using Assets.Scripts.Shop;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Shop
{
    /// <summary>
    /// Отвечает за UI магазина, а также инициализацию контроллеров курсов обмена
    /// </summary>
    public class Shop : BaseScreen
    {
        [SerializeField]
        private ShopView _shopViewInPrefab;
        [SerializeField]
        private GameObject _exchangeTemplate;
        [SerializeField]
        private float _minimumCoefficient;
        [SerializeField]
        private float _maximumCoefficient;
        [SerializeField]
        private List<ExchangeRate> _rates;

        private ShopView _currentShopView;
        private float _pickedCoefficient;
        
        public override void Initialize(ScreenType screenType)
        {
            var canvasTransform = MainManager.ScreenManager.MainCanvas.transform;
            
            var shopUI = Instantiate(_shopViewInPrefab.ShopUI, canvasTransform);
            _currentShopView = shopUI.GetComponent<ShopView>();
            
            _pickedCoefficient = Random.Range(_minimumCoefficient, _maximumCoefficient);
            foreach (var rate in _rates)
            {
                CreateAndInitializeExchangeItem(rate);
            }
        }
        
        private void CreateAndInitializeExchangeItem(ExchangeRate rate)
        {
            var rateObject = Instantiate(_exchangeTemplate, _currentShopView.Content.transform);
            rateObject.GetComponent<ExchangeRateView>().Initialize(rate, _pickedCoefficient);
            rateObject.GetComponent<ExchangeRateController>().Initialize(rate, _pickedCoefficient);
        }
        
        [UsedImplicitly]
        private void CloseShop()
        {
            Destroy(gameObject);
        }
    }
}
