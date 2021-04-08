using System.Collections;
using System.Collections.Generic;
using BuildingSystem;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PieceOfPlaceholderInfoView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _currentResource;
   [SerializeField] private TextMeshProUGUI _requiredResource;
   [SerializeField] private Image _imageResource;

   private float amont;

   public void Initialize(Resource resource, Sprite resourceImage)
   {
       amont = resource.Amount;
       _requiredResource.text = amont.ToString();
       _imageResource.sprite = resourceImage;
   }

   public void ShowPlaceholderInformation(Resource resource)
   {
       var currentResource = amont - resource.Amount;
       _currentResource.text = currentResource.ToString();
   }
}
