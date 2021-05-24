using System;
using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/DiagonalArrowBuff", order = 6)]
    public class DiagonalArrowBuffSettings : SettingsBuff
    {
        [SerializeField]
        private bool _hasDiagonalArrows;
        
        public override IBuff CreateBuff(PersonCharacteristics personCharacteristics)
        {
            return new DiagonalProjectileBuff(_hasDiagonalArrows, (PlayerCharacteristics)personCharacteristics);
        }
    }
}
