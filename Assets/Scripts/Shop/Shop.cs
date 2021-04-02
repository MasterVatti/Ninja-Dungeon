using System.Collections.Generic;
using Assets.Scripts.Shop;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Shop
{
    /// <summary>
    /// Отвечает за UI магазина, а также инициализацию контроллеров курсов обмена
    /// </summary>
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private GameObject _exchangeTemplate;

        [SerializeField]
        private float _minimumCoefficient;
        [SerializeField]
        private float _maximumCoefficient;

        [SerializeField]
        private List<ExchangeRate> _rates;

        private float _pickedCoefficient;

        private void Start()
        {
            _pickedCoefficient = Random.Range(_minimumCoefficient, _maximumCoefficient);

            foreach (var rate in _rates)
            {
                var rateObject = CreateExchangeItem(rate);

                var inputController = rateObject.GetComponent<ExchangeRateController>();
                inputController.Initialize(rate, _pickedCoefficient);
            }
        }

        private GameObject CreateExchangeItem(ExchangeRate rate)
        {
            var rateObject = Instantiate(_exchangeTemplate, transform);
            rateObject.GetComponent<ExchangeRateView>().Initialize(rate, _pickedCoefficient);
            return rateObject;
        }
    }
}
