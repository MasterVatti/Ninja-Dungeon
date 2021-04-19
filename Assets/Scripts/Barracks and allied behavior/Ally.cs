using UnityEngine;
using UnityEngine.UI;

namespace Barracks_and_allied_behavior
{
    public class Ally : MonoBehaviour
    {
        public Image AllyIcon => _allyIcon;
        public int Price => _price;
        public string  Description => _description;
        
        [SerializeField]
        private Image _allyIcon;
        [SerializeField]
        private int _price;
        [SerializeField]
        private string _description;
    }
}
