using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Barracks_and_allied_behavior
{
    public class AllyItemView : MonoBehaviour
    {
        [SerializeField]
        private Image _allyIcon;
        [SerializeField]
        private TextMeshProUGUI _descriptionField;
        [SerializeField]
        private TextMeshProUGUI _priceField;

        public void Initialize(Ally ally)
        {
            _allyIcon = ally.AllyIcon;
            _descriptionField.text = ally.Description;
            _priceField.text = ally.Price.ToString();
        }

        public void AllyBuyButtonClick()
        {
        }
    }
}