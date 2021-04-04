using System;
using System.Globalization;
using Assets.Scripts.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    /// <summary>
    /// Отвечает за логику строки в таблице всех курсов:
    /// Обрабатывает нажатия на кнопку обмен и ввод нового кол-ва ресурсов
    /// </summary>
    public class ExchangeRateController : MonoBehaviour
    {
        [SerializeField]
        private Button _exchangeButton;
        [SerializeField]
        private TMP_InputField _sourceAmountInput;

        private ExchangeRate _rate;
        private float _rateCoefficient;
        private float _playerCoefficient;

        public void Initialize(ExchangeRate rate, float coefficient)
        {
            _playerCoefficient = coefficient;
            _rateCoefficient = rate.ResultResource.Amount / rate.SourceResource.Amount;
            _rate = rate;

            _exchangeButton.onClick.AddListener(ExchangeButtonClicked);
            _sourceAmountInput.onValueChanged.AddListener(UpdateResultAmount);
        }

        private void ExchangeButtonClicked()
        {
            var resourceToPay = _rate.SourceResource.Type;
            var resourceToGet = _rate.ResultResource.Type;

            var sourceResourceAmountValue =
                Convert.ToInt32(Math.Round(_rate.SourceResource.Amount * _playerCoefficient, 0));
            var resultResourceAmountValue =
                Convert.ToInt32(Math.Round(_rate.ResultResource.Amount * _playerCoefficient, 0));

            MainManager.ResourceManager.Pay(resourceToPay, sourceResourceAmountValue);
            MainManager.ResourceManager.AddResource(resourceToGet, resultResourceAmountValue);
        }

        private void UpdateResultAmount(string newValue)
        {
            var resultAmount =
                Convert.ToInt32(Math.Round(float.Parse(newValue) * _playerCoefficient * _rateCoefficient, 0));

            var resultAmountInputField = GetComponent<ExchangeRateView>().ResultAmount;
            resultAmountInputField.text = resultAmount.ToString(CultureInfo.InvariantCulture);
        }
    }
}
