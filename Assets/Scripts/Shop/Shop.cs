using System;
using System.Collections.Generic;
using System.Globalization;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Shop
{
    /// <summary>
    /// Отвечает за UI магазина, а также инициализацию контроллеров курсов обмена
    /// </summary>
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private GameObject ExchangeTemplate;

        [SerializeField]
        private float _minimumCoefficient;
        [SerializeField]
        private float _maximumCoefficient;

        [SerializeField]
        private List<ExchangeRate> _rates;

        private float _pickedCoefficient;

        private void Start()
        {
            _pickedCoefficient =
                Random.Range(_minimumCoefficient, _maximumCoefficient);

            foreach (var rate in _rates)
            {
                var rateObject = CreateExchangeItem(rate);

                var inputController =
                    rateObject.GetComponent<ExchangeRateController>();
                inputController.Initialize(rate, _pickedCoefficient);
            }
        }

        private GameObject CreateExchangeItem(ExchangeRate rate)
        {
            var resourceAmountValue = (int) (rate.ResultResource.Amount *
                                             _pickedCoefficient);

            var rateObject = Instantiate(ExchangeTemplate, transform);

            var sourceImage = rateObject.transform.GetChild(1)
                .GetComponent<Image>();
            var sourceName = rateObject.transform.GetChild(2)
                .GetComponent<Text>();
            var sourceAmount = rateObject.transform.GetChild(3)
                .GetComponent<TMP_InputField>();

            var resultImage = rateObject.transform.GetChild(4)
                .GetComponent<Image>();
            var resultName = rateObject.transform.GetChild(5)
                .GetComponent<Text>();
            var resultAmount = rateObject.transform.GetChild(6)
                .GetComponent<TMP_InputField>();

            sourceName.text = Enum.GetName(typeof(ResourceType),
                rate.SourceResource.Type);
            sourceImage.sprite = rate.SourceResourceIcon;
            sourceAmount.text = rate.SourceResource.Amount.ToString(
                CultureInfo.InvariantCulture);

            resultName.text = Enum.GetName(typeof(ResourceType),
                rate.ResultResource.Type);
            resultImage.sprite = rate.ResultResourceIcon;
            resultAmount.text = resourceAmountValue.ToString(
                CultureInfo.InvariantCulture);

            return rateObject;
        }
    }
}
