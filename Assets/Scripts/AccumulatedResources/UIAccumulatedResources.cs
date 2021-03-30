using TMPro;
using UnityEngine;

/// <summary>
/// Класс выводит в UI максимальное значение и текущее
/// </summary>
public class UIAccumulatedResources : MonoBehaviour
{
   [SerializeField]
   private TextMeshProUGUI _currentResource;
   [SerializeField]
   private TextMeshProUGUI _maxResource;

   private Transform _position;
   private RectTransform _rectTransform;
   private ResourceMiner _resourceMiner;

   private void Awake()
   {
      _rectTransform = transform as RectTransform;
   }

   private void Update()
   {
      _currentResource.text = _resourceMiner.CurrentResourceCount.ToString();
      _maxResource.text = _resourceMiner.MaxStorage.ToString();
      
      UpdatePositionAccumulatedResources();
   }

   public void Initilize(ResourceMiner resourceMiner,Transform UIposition)
   {
      _resourceMiner = resourceMiner;
      _position = UIposition;
   }

   private void UpdatePositionAccumulatedResources()
   {
      var worldPostion = _position.position;
      var screenPoint = Camera.main.WorldToScreenPoint(worldPostion);
      var accumulatedResourcesParent = transform.parent as RectTransform;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(accumulatedResourcesParent, 
         screenPoint, null, out var localPoint);
      _rectTransform.anchoredPosition = new Vector2(localPoint.x, localPoint.y);
   }
}
