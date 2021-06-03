using ShopResource_shortage_notification;
using UnityEngine;

namespace Shop
{
    /// <summary>
    /// Представляет вьюшку магазина
    /// </summary>
    public class ShopView : MonoBehaviour
    {
        public GameObject ShopUI => _shopUI;
        public GameObject Content => _content;
        public ResourceShortageNotification Notification => _notification;
        
        [SerializeField]
        private GameObject _shopUI;
        [SerializeField]
        private GameObject _content;
        [SerializeField]
        private ResourceShortageNotification _notification;
    }
}
