using System.Collections.Generic;
using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem
{
    [RequireComponent(typeof(Player))]
    public class BuffManager : MonoBehaviour
    {
        private PlayerCharacteristics _playerCharacteristics;
        
        private List<IPassiveBuff> _passiveBuffs;
        private List<IUpdatableBuff> _updatableBuffs;

        private void Awake()
        {
            var personCharacteristics = GetComponent<Player>().PersonCharacteristics;
            _playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();
            
            _passiveBuffs = new List<IPassiveBuff>();
            _updatableBuffs = new List<IUpdatableBuff>();
        }
        

        public void AddBuff(IBuff buff, BuffType buffType)
        {
            switch (buffType)
            {
                case BuffType.PassiveBuff:
                    _passiveBuffs.Add((IPassiveBuff)buff);
                    break;
                case BuffType.UpdatableBuff:
                    _updatableBuffs.Add((IUpdatableBuff)buff);
                    break;
            }
            
            buff.StartBuff(_playerCharacteristics);
        }

        private void Update()
        {
            foreach (var updatableBuff in _updatableBuffs)
            {
                updatableBuff.UpdateBuff(_playerCharacteristics);
            }
        }

        private void StopBuff<T>(List<T> _buffs) where T : IPassiveBuff
        {
            foreach (var buff in _buffs)
            {
                buff.StopBuff(_playerCharacteristics);
            }
        }

        private void OnDestroy()
        {
           StopBuff(_passiveBuffs);
           StopBuff(_updatableBuffs);
        }
    }
}
