using System;
using UnityEngine;

namespace Shop.Prefabs.InsufficientMoneyNotification
{
    /// <summary>
    /// Представляет собой уведомление о том, что у игрока не хватает ресурсов
    /// </summary>
    public class ResourceShortageNotification : MonoBehaviour
    {
        public event Action OkButtonClicked;
        
        public void OkButtonHandler()
        {
            gameObject.SetActive(false);
            OkButtonClicked?.Invoke();
        }
    }
}
