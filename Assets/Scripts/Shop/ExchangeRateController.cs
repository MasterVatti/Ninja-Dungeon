using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop
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
            _rateCoefficient = rate.ResultResource.Amount /
                               rate.SourceResource.Amount;
            _rate = rate;
            
            _exchangeButton.onClick.AddListener(ExchangeButtonClicked);
            _sourceAmountInput.onValueChanged.AddListener(ValueChangeCheck);
        }

        private void ExchangeButtonClicked()
        {
            var resourceToPay = _rate.SourceResource.Type;
            var resourceToGet = _rate.ResultResource.Type;

            MainManager.ResourceManager.Pay(resourceToPay, (int) (_rate
                .SourceResource.Amount * _playerCoefficient));
            MainManager.ResourceManager.AddResource(resourceToGet, (int) (_rate
                .ResultResource.Amount * _playerCoefficient));
        }

        private void ValueChangeCheck(string newValue)
        {
            var resultAmountInputField = transform.GetChild(6)
                .GetComponent<TMP_InputField>();

            if (!float.TryParse(newValue, out _))
            {
                resultAmountInputField.text = "0";
                return;
            }

            var resultAmount = (int)(float.Parse(newValue) *
                               _playerCoefficient *
                               _rateCoefficient);
            
            resultAmountInputField.text =
                resultAmount.ToString(CultureInfo.InvariantCulture);
        }
    }
}
