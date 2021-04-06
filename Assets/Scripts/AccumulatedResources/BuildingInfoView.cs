using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildingInfoView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameBuilding;
    
    protected void ShowNameBuilding(string name)
    {
        _nameBuilding.text = name;
    }
    
    public void Initialize(Vector3 positionUI, string name)
    {
         
    }
}
