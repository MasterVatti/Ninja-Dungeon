using Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс выводит в UI максимальное значение и текущее
/// </summary>
public class MinerView : MonoBehaviour
{
   [SerializeField]
   private TextMeshProUGUI _currentResource;
   [SerializeField]
   private TextMeshProUGUI _maxResource;
   [SerializeField]
   private Image _image;
   
   private ResourceMiner _resourceMiner;
   
   private void Update()
   {
      _currentResource.text = _resourceMiner.CurrentResourceCount.ToString();
      _maxResource.text = _resourceMiner.MaxStorage.ToString();
   }

   public void Initialize(ResourceMiner resourceMiner, Vector3 positionUI, Sprite sprite)
   {
      _resourceMiner = resourceMiner;

      _image.sprite = sprite;
      var uiTransform = transform;
      uiTransform.position = positionUI;
      uiTransform.rotation = Quaternion.identity;
   }
}
