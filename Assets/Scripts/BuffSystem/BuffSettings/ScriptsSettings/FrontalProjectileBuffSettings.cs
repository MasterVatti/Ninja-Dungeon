using BuffSystem.Buff;
using BuffSystem.BuffInterface;
using UnityEngine;

namespace BuffSystem.BuffSettings.ScriptsSettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/PassiveBuff/FrontalProjectileBuff", order = 7)]
    public class FrontalProjectileBuffSettings : SettingsBuff
    {
        [SerializeField]
        private int _diagonalProjectileNumber;
        public override IBuff CreateBuff()
        {
            return new FrontalProjectileBuff(_diagonalProjectileNumber);
        }
    }
}
