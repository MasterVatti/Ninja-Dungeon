using System;
using System.Globalization;
using Assets.Scripts.Shop;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    /// <summary>
    /// Представляет строку курса обмена
    /// </summary>
    public class ExchangeRateView : MonoBehaviour
    {
        public TMP_InputField SourceAmount => _sourceAmount;
        public TMP_InputField ResultAmount => _resultAmount;
        
        [SerializeField]
        private Image _sourceImage;
        [SerializeField]
        private Text _sourceName;
        [SerializeField]
        private TMP_InputField _sourceAmount;

        [SerializeField]
        private Image _resultImage;
        [SerializeField]
        private Text _resultName;
        [SerializeField]
        private TMP_InputField _resultAmount;

        public void Initialize(ExchangeRate rate, float pickedCoefficient)
        {
            _sourceName.text = Enum.GetName(typeof(ResourceType), rate.SourceResource.Type);
            _sourceImage.sprite = rate.SourceResourceIcon;
            var sourceResourceAmountValue = Math.Round(rate.SourceResource.Amount, 0);
            _sourceAmount.text = sourceResourceAmountValue.ToString(CultureInfo.InvariantCulture);

            _resultName.text = Enum.GetName(typeof(ResourceType), rate.ResultResource.Type);
            _resultImage.sprite = rate.ResultResourceIcon;
        
            var resourceAmountValue = Math.Round(rate.ResultResource.Amount *
                                             pickedCoefficient, 0);
            _resultAmount.text = resourceAmountValue.ToString(CultureInfo.InvariantCulture);
        } 
    }
}
