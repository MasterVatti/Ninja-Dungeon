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
        
        [SerializeField]
        private GameObject _shopUI;
        [SerializeField]
        private GameObject _content;
    }
}
