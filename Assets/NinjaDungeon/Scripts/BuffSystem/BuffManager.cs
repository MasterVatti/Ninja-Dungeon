using System.Collections.Generic;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem
{
    /// <summary>
    /// Класс служит для активации, обновления и остановки бафов
    /// </summary>
    [RequireComponent(typeof(PersonCharacteristics))]
    public class BuffManager : MonoBehaviour
    {
        private List<IPassiveBuff> _passiveBuffs;
        private List<IUpdatableBuff> _updatableBuffs;

        private void Awake()
        {
            _passiveBuffs = new List<IPassiveBuff>();
            _updatableBuffs = new List<IUpdatableBuff>();
        }
        
        public void AddBuff(IBuff buff)
        {
            switch (buff)
            {
                case IUpdatableBuff updatableBuff:
                    _updatableBuffs.Add(updatableBuff);
                    break;
                
                case IPassiveBuff passiveBuff:
                    _passiveBuffs.Add(passiveBuff);
                    break;
            }
            
            buff.StartBuff();
        }

        private void Update()
        {
            foreach (var updatableBuff in _updatableBuffs)
            {
                updatableBuff.UpdateBuff();
            }
        }

        public void StopBuff()
        {
            StopBuff(_passiveBuffs);
            StopBuff(_updatableBuffs);
        }

        private void StopBuff<T>(List<T> _buffs) where T : IPassiveBuff
        {
            foreach (var buff in _buffs)
            {
                buff.StopBuff();
            }
        }

        private void OnDestroy()
        {
           StopBuff(_passiveBuffs);
           StopBuff(_updatableBuffs);
        }
    }
}
