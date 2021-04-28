using System.Collections;
using System.Collections.Generic;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

public class RestoreHealthBuff : IBuff
{
    private int _amountHealthRestored;
    
    public RestoreHealthBuff(int amountHealthRestored)
    {
        _amountHealthRestored = amountHealthRestored;
    }
    
    public void StartBuff(PersonCharacteristics personCharacteristics)
    {
        personCharacteristics.CurrentHp += _amountHealthRestored;
    }
}
