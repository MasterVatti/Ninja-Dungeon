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
        public event Action OnPlayerHasInsufficientFunds;

        [SerializeField]
        private Button _exchangeButton;
        [SerializeField]
        private TMP_InputField _sourceAmountInput;
        [SerializeField]
        private TMP_InputField _finalAmountInput;

        private ExchangeRate _rate;
        private float _rateCoefficient;
        private float _playerCoefficient;

        public void SetInteractable(bool state)
        {
            _exchangeButton.interactable = state;
            _sourceAmountInput.interactable = state;
            _finalAmountInput.interactable = state;
        }

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

            var view = GetComponent<ExchangeRateView>();
            var sourceResourceAmount = Math.Round(float.Parse(view.SourceAmount.text), 0);

            var sourceResourceAmountValue = Convert.ToInt32(Math.Round(sourceResourceAmount, 0));
            var resultResourceAmountValue =
                Convert.ToInt32(Math.Round(sourceResourceAmount * _playerCoefficient * _rateCoefficient, 0));

            if (MainManager.ResourceManager.HasEnough(resourceToPay, sourceResourceAmountValue))
            {
                MainManager.ResourceManager.Pay(resourceToPay, sourceResourceAmountValue);
                MainManager.ResourceManager.AddResource(resourceToGet, resultResourceAmountValue);
            }
            else
            {
                OnPlayerHasInsufficientFunds?.Invoke();
            }
        }

        private void UpdateResultAmount(string newValue)
        {
            try
            {
                var resultValue = float.Parse(newValue);
                var resultAmount =
                    Convert.ToInt32(Math.Round(resultValue * _playerCoefficient * _rateCoefficient, 0));
                var resultAmountInputField = GetComponent<ExchangeRateView>().ResultAmount;
                resultAmountInputField.text = resultAmount.ToString(CultureInfo.InvariantCulture);
            }
            catch (OverflowException)
            {
                SetInputToEmptyString();
            }
        }

        private void SetInputToEmptyString()
        {
            _sourceAmountInput.text = "";
            _finalAmountInput.text = "";
        }
    }
}
