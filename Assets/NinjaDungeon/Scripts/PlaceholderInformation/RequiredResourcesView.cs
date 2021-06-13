using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequiredResourcesView : MonoBehaviour
{
   [SerializeField] 
   private TextMeshProUGUI _currentResource;
   [SerializeField] 
   private TextMeshProUGUI _requiredResource;
   [SerializeField] 
   private Image _imageResource;

   private float _requiredAmount;

   public void Initialize(Resource resource, Sprite resourceImage)
   {
       _requiredAmount = resource.Amount;
       _requiredResource.text = _requiredAmount.ToString();
       _imageResource.sprite = resourceImage;
   }

   public void ShowPlaceholderInformation(Resource resource)
   {
       var currentResource = _requiredAmount - resource.Amount;
       _currentResource.text = currentResource.ToString();
   }
}
