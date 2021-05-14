using Characteristics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Buildings.PlayerCharacteristicsImprove
{
    public class CharacteristicImproveView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _label;
        [SerializeField]
        private CharacteristicImproveSettings _settings;
        [SerializeField]
        private ImprovePurchaseView[] _improvePurchaseViews = new ImprovePurchaseView[2];

        private void Awake()
        {
            _icon.sprite = MainManager.IconsProvider.GetCharacteristicImage(_settings.CharacteristicType);
            
            var playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            var characteristic = playerCharacteristics.GetCharacteristic(_settings.CharacteristicType);
            _label.text = characteristic.StepValue.ToString();
            
            _improvePurchaseViews[0].Initialize(_settings);
            _improvePurchaseViews[1].Initialize(_settings, true);
        }
    }
}
