using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Resources;
using ResourceSystem;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;
    
    private List<Resource> _resources;

    private Managers.ResourceManager _resourceManager;

    private float _time = 1f;

    private float _substracting;





    void Start()
    {
        _substracting = _resourceManager.Substracting;
        _resources = MainManager.ResourceManager.GetResources();
        _resourceManager.OnResourceChanged += StartCoroutines;
    }

    void Update()
    {
        UpdateResourcesAmount();
    }

    void StartCoroutines(float _substracting)
    {
        StartCoroutine(moveResource(_substracting));
    }
    


    public IEnumerator moveResource(float _substracting)
    {
        var speed = _time / _substracting;
        
        yield return new WaitForSeconds(speed);


    }

    private void OnDestroy()
    {
        _resourceManager.OnResourceChanged -=  StartCoroutines;
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
    
    
    
    
}



