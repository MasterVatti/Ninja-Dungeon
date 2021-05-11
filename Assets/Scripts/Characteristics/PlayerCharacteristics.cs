using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Класс для характеристик игрока
    /// </summary>
    public class PlayerCharacteristics : PersonCharacteristics
    {
        private void Awake()
        {
            Characteristics = MainManager.UserData.GetCharacteristics();
        }

        public void ImproveCharacteristic(CharacteristicType type)
        {
            var characteristic = GetCharacteristic(type);
            characteristic.Level += 1;
        }
    }
}
