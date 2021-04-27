using System;
using System.Collections.Generic;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem
{
    [RequireComponent(typeof(Player))]
    public class BuffManager : MonoBehaviour
    {
        private PersonCharacteristics _personCharacteristics;
        
        private List<IBuff> _passiveBuffs = new List<IBuff>();
        private List<IUpdatableBuff> _updatableBuffs = new List<IUpdatableBuff>();

        private void Awake()
        {
            _personCharacteristics = GetComponent<Player>().PlayerCharacteristics;
        }

        public void AddBuff(IBuff buff)
        {
            if (buff is IUpdatableBuff updatableBuff)
            {
                _updatableBuffs.Add(updatableBuff);
            }
            else
            {
                _passiveBuffs.Add(buff);
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

        private void StopBuff<T>(List<T> buffs) where T : IBuff
        {
            foreach (var buff in buffs)
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
