using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Тут хранятся характеристики всех персонажей
    /// </summary>
    public class CharacteristicsManager : MonoBehaviour
    {
        public List<PersonCharacteristics> CharacteristicsAllUnits => _characteristicsAllUnits;

        private List<PersonCharacteristics> _characteristicsAllUnits = new List<PersonCharacteristics>();

        private void Awake()
        {
            AddCharacteristicsOfAllUnits();
        }
    
        public void AddCharacteristic(Person person)
        {
            _characteristicsAllUnits.Add(person.GetComponent<PersonCharacteristics>());
        }
    
        private void AddCharacteristicsOfAllUnits()
        {
            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                AddCharacteristic(enemy);
            }
        
            AddCharacteristic(MainManager.Player.GetComponent<Person>());
        }
    }
}
