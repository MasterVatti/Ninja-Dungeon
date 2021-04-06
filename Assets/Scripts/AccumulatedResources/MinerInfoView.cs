using BuildingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс выводит в UI максимальное значение и текущее
/// </summary>
public class MinerInfoView  : BuildingInfoView
{
   [SerializeField]
   private TextMeshProUGUI _currentResource;
   [SerializeField]
   private TextMeshProUGUI _maxResource;
   [SerializeField]
   private Image _image;
   
   private ResourceMiner _resourceMiner;
   private Transform test;
   
   private void Update()
   {
      _currentResource.text = _resourceMiner.CurrentResourceCount.ToString();
      _maxResource.text = _resourceMiner.MaxStorage.ToString();
   }

   public void Initialize(ResourceMiner resourceMiner, Vector3 positionUI, Sprite sprite, string name)
   {
      _resourceMiner = resourceMiner;

      _image.sprite = sprite;
      transform.position = positionUI;
      transform.rotation = Quaternion.identity;
      
      ShowNameBuilding(name);
   }
}
