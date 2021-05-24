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
        private ShopView _shopView;
        [SerializeField]
        private GameObject _exchangeTemplate;
        [SerializeField]
        private float _minimumCoefficient;
        [SerializeField]
        private float _maximumCoefficient;
        [SerializeField]
        private List<ExchangeRate> _rates;

        private float _pickedCoefficient;
        private List<ExchangeRateController> _rateControllers = new List<ExchangeRateController>();
        
        public override void Initialize(ScreenType screenType)
        {
            _pickedCoefficient = Random.Range(_minimumCoefficient, _maximumCoefficient);
            
            foreach (var rate in _rates)
            {
                var rateController = CreateAndInitializeExchangeItem(rate);
                _rateControllers.Add(rateController);
                
                rateController.OnPlayerHasInsufficientFunds += OnPlayerHasInsufficientFunds;
            }
        }

        private ExchangeRateController CreateAndInitializeExchangeItem(ExchangeRate rate)
        {
            var rateObject = Instantiate(_exchangeTemplate, _shopView.Content.transform);
            rateObject.GetComponent<ExchangeRateView>().Initialize(rate, _pickedCoefficient);
            rateObject.GetComponent<ExchangeRateController>().Initialize(rate, _pickedCoefficient);

            return rateObject.GetComponent<ExchangeRateController>();
        }
        
        private void OnPlayerHasInsufficientFunds()
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.InsufficientResources);
        }
        
        private void OnDestroy()
        {
            foreach (var exchangeRateController in _rateControllers)
            {
                exchangeRateController.OnPlayerHasInsufficientFunds -= OnPlayerHasInsufficientFunds;
            }
        }

        [UsedImplicitly]
        private void CloseShop()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}
