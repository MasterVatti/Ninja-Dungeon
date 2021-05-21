using UnityEngine;

namespace Energy
{
    /// <summary>
    /// Отвечает за восстановление энергии
    /// </summary>
    public class EnergyRestore : MonoBehaviour
    {
        private const int SecondsInMinute = 60;
        private const int MinutesInHour = 60;
        
        [SerializeField]
        private int _cooldownHours;
        [SerializeField]
        private int _cooldownMinutes;
        [SerializeField] 
        private int _restoreCount;
        [SerializeField] 
        private EnergyManager _energyManager;

        private float _currentSeconds;
        private int _currentMinutes;
        private int _currentHour;
        
        private void Update()
        {
            if (_currentSeconds >= SecondsInMinute)
            {
                _currentSeconds = 0;
                _currentMinutes++;
                CheckForNewMinute();
                CheckForDoingCooldown();
            }
            else
            {
                _currentSeconds += Time.deltaTime;
            }
        }

        private void CheckForNewMinute()
        {
            if (_currentMinutes >= MinutesInHour)
            {
                _currentMinutes = 0;
                _currentHour++;
            }
        }
        
        private void CheckForDoingCooldown()
        {
            if ((_currentHour == _cooldownHours) && (_currentMinutes == _cooldownMinutes))
            {
                _energyManager.IncreaseEnergy(_restoreCount);
                _currentHour = 0;
                _currentMinutes = 0;
            }
        }
    }
}
