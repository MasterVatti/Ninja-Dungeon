using TMPro;
using UnityEngine;

/// <summary>
/// Класс для базовых виджетов
/// </summary>

public class BuildingInfoView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameBuilding;

    private void ShowNameBuilding(string nameBuilding)
    {
        _nameBuilding.text = nameBuilding;
    }
    
    public virtual void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
    {
        transform.position = uiAttachPoint.position;
        transform.rotation = Quaternion.identity;
        
        ShowNameBuilding(nameBuilding);
    }
}
