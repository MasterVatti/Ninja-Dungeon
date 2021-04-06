using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text _gold;
    [SerializeField] private Text _lumber;
    [SerializeField] private Text _crystal;

    private List<Resource> _resources;


    void Start()
    {
       _resources = MainManager.ResourceManager.GetResources();
    }

    // Update is called once per frame
    void Update()
    {
        _gold.text = _resources[0].Amount.ToString();
        _lumber.text = _resources[1].Amount.ToString();
        _crystal.text = _resources[2].Amount.ToString();
    }
    
}
