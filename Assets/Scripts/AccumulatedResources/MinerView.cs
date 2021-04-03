using TMPro;
using UnityEngine;

/// <summary>
/// Класс выводит в UI максимальное значение и текущее
/// </summary>
public class MinerView : MonoBehaviour
{
   [SerializeField]
   private TextMeshProUGUI _currentResource;
   [SerializeField]
   private TextMeshProUGUI _maxResource;
   
   private ResourceMiner _resourceMiner;
   private Transform test;
   
   private void Update()
   {
      _currentResource.text = _resourceMiner.CurrentResourceCount.ToString();
      _maxResource.text = _resourceMiner.MaxStorage.ToString();
   }

   public void Initilize(ResourceMiner resourceMiner, Vector3 positionUI)
   {
      _resourceMiner = resourceMiner;

      transform.position = positionUI;
      transform.rotation = Quaternion.identity;
   }
}
