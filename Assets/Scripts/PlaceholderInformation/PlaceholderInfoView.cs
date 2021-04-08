using System;
using System.Collections;
using System.Collections.Generic;
using BuildingSystem;
using Managers;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaceholderInfoView : MonoBehaviour
{
    [SerializeField] 
    private PieceOfPlaceholderInfoView _pieceOfPlaceholderInfoViewPrefab;
    [SerializeField] 
    private List<ResourceImage> _resourceImages = new List<ResourceImage>();

    private List<Resource> _resourceList;
  //  private List<PieceOfPlaceholderInfoView> _piecesOfPlaceholderInfoView=new List<PieceOfPlaceholderInfoView>();
    private Dictionary<Resource, PieceOfPlaceholderInfoView> _blabla;
  


    public void Initialize(BuildingController placeholder)
    {
        _blabla = new Dictionary<Resource, PieceOfPlaceholderInfoView>();
        placeholder.OnPayForBuilding += lalal;
        Debug.Log("инициализация UI в инфоВью");
        _resourceList = placeholder.RequiredResource;//запоминаем список ресурсов. 
        Vector3 uiPosition = placeholder.GetComponent<Transform>().position;
        //К каждому ресурсу в списке создадим по префабу Вьюшки.
        foreach (var resource in _resourceList)
        {
            var pieceOfPlaceholderInfoView=Instantiate(_pieceOfPlaceholderInfoViewPrefab,uiPosition, Quaternion.identity, transform);
           // _piecesOfPlaceholderInfoView.Add(pieceOfPlaceholderInfoView);
            _blabla.Add(resource,pieceOfPlaceholderInfoView);
            pieceOfPlaceholderInfoView.Initialize(resource,GetResourceSprite(resource));
            Debug.Log("добавление "+resource);
        }
        
    }

    private Sprite GetResourceSprite(Resource resource)
    {
        foreach (var resourceImage in _resourceImages)
        {
            if (resourceImage.Type == resource.Type)
            {
                return resourceImage.Sprite;
            }
        }

        return null;
    }

    private void lalal()
    {
        Debug.Log("Ресурс добавлен");
        foreach (var VARIABLE in _resourceList)
        {
            Debug.Log(VARIABLE + "/"+VARIABLE.Type+":"+VARIABLE.Amount);
            _blabla[VARIABLE].ShowPlaceholderInformation(VARIABLE);
        }

       
      //  foreach (var piece in _piecesOfPlaceholderInfoView)
      //  {
      //      //piece.ShowPlaceholderInformation(resource);
      //  }
    }
}
