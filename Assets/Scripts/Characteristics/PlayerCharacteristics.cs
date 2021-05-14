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
    }
}
