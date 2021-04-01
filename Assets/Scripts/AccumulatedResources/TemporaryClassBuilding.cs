using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//используется временно вместо Building
public class TemporaryClassBuilding : MonoBehaviour
{
    public Transform PositionUI => _positionUI;
    
    [SerializeField]
    private Transform _positionUI;
}
