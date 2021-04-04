using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int Energy => _energyCount;
    
    [SerializeField] 
    private int _energyCount = 100;
    
    public void EnergyDecrease(int decreaseNumber)
    {
        _energyCount -= decreaseNumber;
        if (_energyCount < 0)
        {
            _energyCount = 0;
        }
        Debug.Log(_energyCount);
    }
}
