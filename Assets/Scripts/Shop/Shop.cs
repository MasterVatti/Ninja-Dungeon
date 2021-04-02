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
                CreateAndInitializeExchangeItem(rate);
            }
        }

        private void CreateAndInitializeExchangeItem(ExchangeRate rate)
        {
            var rateObject = Instantiate(_exchangeTemplate, transform);
            rateObject.GetComponent<ExchangeRateView>().Initialize(rate, _pickedCoefficient);
            rateObject.GetComponent<ExchangeRateController>().Initialize(rate, _pickedCoefficient);
        }
    }
}
