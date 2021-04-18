using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public ResourcesView ResourcesView => _resourcesView;
    
    [SerializeField]
    private ResourcesView _resourcesView;
    
    
}
