using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class ResourceRewardLabel : MonoBehaviour
    {
        [SerializeField]
        private Image _imageResource;
        [SerializeField]
        private TextMeshProUGUI _amountResource;
        
        public void Initialize(Sprite sprite, int amount)
        {
            _imageResource.sprite = sprite;
            _amountResource.text = amount.ToString();
        }
    }
}