using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/DiagonalArrowBuff", order = 6)]
    public class DiagonalArrowBuffSettings : SettingsBuff
    {
        [SerializeField]
        private int _diagonalArrowsNumber;
        public override IBuff CreateBuff()
        {
            return new DiagonalArrowBuff(_diagonalArrowsNumber);
        }
    }
}
