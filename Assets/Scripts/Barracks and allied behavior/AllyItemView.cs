using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за поле и настройку конкретного поля союзника,
    /// покупку(проверку наличия ресурсов) оплату и инстанциацию префаба.
    /// </summary>
    public class AllyItemView : MonoBehaviour
    {
        [SerializeField]
        private Image _allyIcon;
        [SerializeField]
        private TextMeshProUGUI _descriptionField;
        [SerializeField]
        private List<Image> _resourceImages;
        [SerializeField]
        private List<TextMeshProUGUI> _priceFields;

        private AlliesSetting _ally;
        private Barrack _barrack;

        public void Initialize(AlliesSetting ally, Barrack barrack)
        {
            _barrack = barrack;
            _ally = ally;
            Initialize();
        }

        [UsedImplicitly]
        public void AllyBuyButtonClick()
        {
            if (MainManager.ResourceManager.HasEnough(_ally.Price))
            {
                MainManager.ResourceManager.Pay(_ally.Price);
                _barrack.CreateAlly(_ally);

                MainManager.ScreenManager.CloseTopScreen();
            }
        }

        private void Initialize()
        {
            _allyIcon.sprite = _ally.AllyIcon;
            _descriptionField.text = _ally.Description;
            for (var i = 0; i < _ally.Price.Count; i++)
            {
                _resourceImages[i].gameObject.SetActive(true);
                _priceFields[i].gameObject.SetActive(true);

                _resourceImages[i].sprite = MainManager.IconsProvider
                    .GetResourceSprite(_ally.Price[i].Type);
                _priceFields[i].text = _ally.Price[i].Amount
                    .ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}