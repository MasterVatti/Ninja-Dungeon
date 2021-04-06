using TMPro;
using UnityEngine;

public class BuildingInfoView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameBuilding;

    protected void ShowNameBuilding(string nameBuilding)
    {
        _nameBuilding.text = nameBuilding;
    }
    
    public void Initialize(Vector3 positionUI, string nameBuilding)
    {
        transform.position = positionUI;
        transform.rotation = Quaternion.identity;
        
        ShowNameBuilding(nameBuilding);
    }
}
