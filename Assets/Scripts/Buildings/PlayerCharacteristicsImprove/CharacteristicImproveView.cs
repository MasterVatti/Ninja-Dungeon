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
            var characteristicType = _settings.CharacteristicType;
            _icon.sprite = MainManager.IconsProvider.GetCharacteristicImage(characteristicType);
            
            var playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            var characteristic = playerCharacteristics.GetCharacteristic(characteristicType);
            _label.text = characteristic.StepValue.ToString();

            _improvePurchaseViews[0].Initialize(_settings.Cost);
            _improvePurchaseViews[1].Initialize(_settings.VariantCost);
            
            foreach (var purchaseView in _improvePurchaseViews)
            {
                purchaseView.SetButtonOnClick(delegate { OnClick(purchaseView); });
            }

            void OnClick(ImprovePurchaseView purchaseView)
            {
                playerCharacteristics.ImproveCharacteristic(characteristicType);
                MainManager.ResourceManager.Pay(purchaseView.Resources);
                _improvePurchaseViews[0].SetResources(_settings.Cost);
                _improvePurchaseViews[1].SetResources(_settings.VariantCost);
            }
        }
    }
}
