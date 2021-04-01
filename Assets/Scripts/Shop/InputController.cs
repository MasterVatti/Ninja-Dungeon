using System;
using UnityEngine;

namespace Shop
{
    public class InputController: MonoBehaviour
    {
        public event Action OnExchangeButtonClicked;
        public event Action<double> SourceResourceAmountValueChanged;  
        
        public void ExchangeButtonClicked()
        {
            OnExchangeButtonClicked?.Invoke();
        }

        public void ValueChangeCheck(string newValue)
        {
            SourceResourceAmountValueChanged?.Invoke(Convert.ToDouble(newValue));
        }
    }
}

