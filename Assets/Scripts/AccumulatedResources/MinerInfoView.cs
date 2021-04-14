using BuildingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс для показа информации о добытых ресурсах майнера
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

    private void Update()
    {
        _currentResource.text = _resourceMiner.CurrentResourceCount.ToString();
        _maxResource.text = _resourceMiner.MaxStorage.ToString();
    }

    public override void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
    {
        _resourceMiner = building.GetComponent<ResourceMiner>();
        
        _image.sprite = MainManager.IconsProvider.GetResourceSprite(_resourceMiner.ExtractableResource);
        
        base.Initialize(building, uiAttachPoint, nameBuilding);
    }
}