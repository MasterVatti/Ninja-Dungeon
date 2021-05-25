using System;
using UnityEngine;

namespace Energy
{
    /// <summary>
    /// Отвечает за управление энергией
    /// </summary>
    public class EnergyManager : MonoBehaviour
    {
        private const string LAST_PLAY_TIME_KEY = "LastPlayTime";
        private const string ENERGY_COUNT_KEY = "EnergyCount";

        public int CurrentEnergy { get; private set; }
        public float EnergyRecoveryTime { get; private set; }
        public int MaximalEnergy => _maximalEnergy;

        [SerializeField]
        private int _maximalEnergy = 100;
        [SerializeField]
        private float _oneEnergyRestoreTimeSec = 5f;

        private float _lastRestoreTime;

        private void Awake()
        {
            CurrentEnergy = PlayerPrefs.GetInt(ENERGY_COUNT_KEY, _maximalEnergy);
            _lastRestoreTime = Time.realtimeSinceStartup;
            RestoreEnergyForOfflineTime();
        }

        private void RestoreEnergyForOfflineTime()
        {
            if (!DateTime.TryParse(PlayerPrefs.GetString(LAST_PLAY_TIME_KEY), out var lastPlayTime))
            {
                lastPlayTime = DateTime.UtcNow;
            }

            var offlineTime = DateTime.UtcNow - lastPlayTime;
            var offlineTimeInSeconds = offlineTime.TotalSeconds;
            var restoredEnergyAmount = offlineTimeInSeconds / _oneEnergyRestoreTimeSec;

            CurrentEnergy = (int) Math.Min(CurrentEnergy + restoredEnergyAmount, _maximalEnergy);
        }

        private void Update()
        {
            if (_lastRestoreTime + _oneEnergyRestoreTimeSec < Time.realtimeSinceStartup &&
                CurrentEnergy < _maximalEnergy)
            {
                _lastRestoreTime = Time.realtimeSinceStartup;
                CurrentEnergy++;
            }

            if (CurrentEnergy < _maximalEnergy)
            {
                EnergyRecoveryTime = _lastRestoreTime + _oneEnergyRestoreTimeSec - Time.realtimeSinceStartup;
            }
        }
        
        private void OnDestroy()
        {
            DontDestroyOnLoad(gameObject);
            PlayerPrefs.SetString(LAST_PLAY_TIME_KEY, DateTime.UtcNow.ToString());
            PlayerPrefs.SetInt(ENERGY_COUNT_KEY, CurrentEnergy);
        }

        public bool HasEnoughEnergy(int amount)
        {
            return CurrentEnergy >= amount;
        }
    
        public void DecreaseEnergy(int decreaseNumber)
        {
            CurrentEnergy = Mathf.Clamp(CurrentEnergy - decreaseNumber, 0, _maximalEnergy);
        }

        public void IncreaseEnergy(int increaseNumber)
        {
            CurrentEnergy = Mathf.Clamp(CurrentEnergy + increaseNumber, 0, _maximalEnergy);
        }
    }
}
