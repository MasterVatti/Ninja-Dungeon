using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;
    
    private List<Resource> _resources;

    private float _time = 0.2f;
    
    private const int _count = 10;


    void Start()
    {
        _resources = MainManager.ResourceManager.GetResources();
    }

    void Update()
    {
        //UpdateResourcesAmount();
    }

    private void UpdateResourcesAmount()
    {
        for (int i = 0; i < _resourceLabels.Count; i++)
        {
            for (int j = 0; j < _resources.Count; j++)
            {
                if (_resourceLabels[i].Type == _resources[j].Type )
                {
                    _resourceLabels[i].Label.text = _resources[j].Amount.ToString();
                    break;
                }
            }
        }
    }

    public void StartEnumerator(int value,int index)
    {
        var _resources = _resources[index]
        var raz = value / _count;
        var ost = value % _count;
        for (int i = 0; i < raz; i++)
        {
            _resources.Amount += _count;
        }
        _resources.Amount += ost;
    }
    
}
