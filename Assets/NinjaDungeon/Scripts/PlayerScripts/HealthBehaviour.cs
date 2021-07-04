using System;
using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using Characteristics;
using ProjectileLauncher;
using UnityEngine;

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
            _person.PersonCharacteristics.CurrentHp -= damage;
            if (_person.PersonCharacteristics.CurrentHp <= 0)
            {
                _person.PersonCharacteristics.CanAttack = false;
                _person.PersonCharacteristics.CanMove = false;
                OnDead?.Invoke(_person);
            }
        }
        
        public void ApplyDamage(Team damageDealerTeam, int damage)
        {
            if (damageDealerTeam == _team)
            {
                return;
            }

            _person.PersonCharacteristics.CurrentHp -= damage;
            if (_person.PersonCharacteristics.CurrentHp <= 0)
            {
                _person.PersonCharacteristics.CanAttack = false;
                _person.PersonCharacteristics.CanMove = false;
                OnDead?.Invoke(_person);
            }
        }

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