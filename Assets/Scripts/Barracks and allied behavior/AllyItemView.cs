using System.Globalization;
using JetBrains.Annotations;
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
        private Image _firstResourceImage;
        [SerializeField]
        private TextMeshProUGUI _firstPriceField;
        [SerializeField]
        private Image _secondResourceImage;
        [SerializeField]
        private TextMeshProUGUI _secondPriceField;

        private AlliesListSetting _ally;

        public void Initialize(AlliesListSetting ally)
        {
            _ally = ally;
           _allyIcon.sprite= ally.AllyIcon;
           _descriptionField.text = ally.Description;
           _firstResourceImage.sprite = MainManager.IconsProvider.GetResourceSprite(ally.FirstType);
           _firstPriceField.text = ally.FirstPrice.ToString(CultureInfo.InvariantCulture);
           
           if (ally.SecondPrice != 0)
           {
               _secondPriceField.text = ally.SecondPrice.ToString(CultureInfo.InvariantCulture);
               _secondResourceImage.sprite = MainManager.IconsProvider.GetResourceSprite(ally.SecondType);
           }
           else
           {
               Destroy(_secondResourceImage);
           }
        }
        
        [UsedImplicitly]
        public void AllyBuyButtonClick()
        {
            if (MainManager.ResourceManager.HasEnough(_ally.FirstType, _ally.FirstPrice))
            {
                if (_ally.SecondPrice != 0 && MainManager.ResourceManager.HasEnough(_ally.SecondType, _ally.SecondPrice))
                {
                    MainManager.ResourceManager.Pay(_ally.FirstType,_ally.FirstPrice);
                    MainManager.ResourceManager.Pay(_ally.SecondType,_ally.SecondPrice);
                    CreateAlly();
                }
                else
                {
                    MainManager.ResourceManager.Pay(_ally.FirstType,_ally.FirstPrice);
                    CreateAlly();
                }
            }
        }

        private void CreateAlly()
        {
            var ally = Instantiate(_ally.AllyPrefab, _ally.SpawnPoint.position, Quaternion.identity);

            MainManager.ScreenManager.CloseTopScreen(); 
        }
    }
}