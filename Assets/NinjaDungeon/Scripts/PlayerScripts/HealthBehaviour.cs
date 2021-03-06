using System;
using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using Characteristics;
using JetBrains.Annotations;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье
    /// </summary>
    [RequireComponent(typeof(PersonCharacteristics))]
    public class HealthBehaviour : MonoBehaviour
    {
        public event Action<Person> OnDead;

        [SerializeField]
        private Team _team;

        private Person _person;

        private void Awake()
        {
            _person = GetComponent<Person>();
        }

        public void ApplyDamage(int damage)
        {
            if (_person.PersonCharacteristics.IsDeath)
            {
                return;
            }
            _person.PersonCharacteristics.CurrentHp -= damage;
            if (_person.PersonCharacteristics.CurrentHp <= 0 )
            {
                _person.PersonCharacteristics.IsDeath = true;
                OnDead?.Invoke(_person);
            }
        }

        public void HealthRecovery(int recovery)
        {
            var characteristics = _person.PersonCharacteristics;
            var newHp = characteristics.CurrentHp + recovery;
            _person.PersonCharacteristics.CurrentHp = newHp >= characteristics.MaxHp ? characteristics.MaxHp : newHp;
        }

        public void ApplyDamage(Team damageDealerTeam, int damage)
        {
            if (damageDealerTeam == _team || _person.PersonCharacteristics.IsDeath)
            {
                return;
            }

            _person.PersonCharacteristics.CurrentHp -= damage;
            if (_person.PersonCharacteristics.CurrentHp <= 0)
            {
                _person.PersonCharacteristics.IsDeath = true;
                OnDead?.Invoke(_person);
            }
        }
        
        [UsedImplicitly]
        public void Death()
        {
            if (!CompareTag(GlobalConstants.PLAYER_TAG))
            {
                Destroy(gameObject);
            }
            else
            {
                var context = new PortalContext
                {
                    SceneName = GlobalConstants.MAIN_SCENE_TAG
                };
                
                MainManager.ScreenManager.OpenScreenWithContext(ScreenType.DeathScreen, context);
            }
        }
    }
}