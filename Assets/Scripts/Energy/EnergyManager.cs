using System;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int Energy => _energyCount;
    
    [SerializeField]
    private int _energyCount = 100;
    [SerializeField]
    private int _maximalEnergy = 100;

    private void Awake()
    {
        SetCurrentEnergyToMaximal();
    }
    
    private void OnDestroy()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void EnergyDecrease(int decreaseNumber)
    {
        _energyCount -= decreaseNumber;
        if (_energyCount < 0)
        {
            _energyCount = 0;
        }
    }

    public void EnergyIncrease(int increaseNumber)
    {
        _energyCount += increaseNumber;
        SetCurrentEnergyToMaximal();
    }

    private void SetCurrentEnergyToMaximal()
    {
        if (_energyCount > _maximalEnergy)
        {
            _energyCount = _maximalEnergy;
        }
    }
}
