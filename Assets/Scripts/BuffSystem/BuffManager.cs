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
        private PersonCharacteristics _personCharacteristics;
        
        private Stack<IPassiveBuff> _passiveBuffs;
        private Stack<IUpdatableBuff> _updatableBuffs;

        private void Awake()
        {
            _personCharacteristics = GetComponent<PersonCharacteristics>();

            _passiveBuffs = new Stack<IPassiveBuff>();
            _updatableBuffs = new Stack<IUpdatableBuff>();
        }
        

        public void AddBuff(IBuff buff, BuffType buffType)
        {
            switch (buffType)
            {
                case BuffType.PassiveBuff:
                    _passiveBuffs.Push((IPassiveBuff)buff);
                    break;
                case BuffType.UpdatableBuff:
                    _updatableBuffs.Push((IUpdatableBuff)buff);
                    break;
            }
            
            buff.StartBuff(_personCharacteristics);
        }

        private void Update()
        {
            foreach (var updatableBuff in _updatableBuffs)
            {
                updatableBuff.UpdateBuff(_personCharacteristics);
            }
        }

        private void StopBuff<T>(Stack<T> _buffs) where T : IPassiveBuff
        {
            foreach (var buff in _buffs)
            {
                buff.StopBuff(_personCharacteristics);
            }
        }

        private void OnDestroy()
        {
           StopBuff(_passiveBuffs);
           StopBuff(_updatableBuffs);
        }
    }
}
