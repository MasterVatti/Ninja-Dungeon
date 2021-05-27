using System;
using System.Collections;
using UnityEngine;

namespace ExperienceSystem
{
    public class ExperienceControllerUpperWorld : MonoBehaviour
    {
        // Класс Отвечает за логику начисления опыта
        public static event Action<int> OnExperienceChanged;
    
        [SerializeField] 
        private float _animationTime;
        [SerializeField]
        private Characteristics.PlayerCharacteristics _playerExperience;
        [SerializeField]
        private ExperienceView _experienceView;
        [SerializeField]
        private float _saveTime;
    
        private int _currentExperience;
        private float _currentValue;
        private float _elapsedTime;
        private Coroutine _currentCoroutine;
        private int _startLevel = 1;
        private int _startMaxValue = 100;
    

        void Start()
        {
            //  _currentLevelPlayer =_experienceView.LevelPlayer.text;
            //  LoadingExperienceFields();
            //  if (Convert.ToInt32(_experienceView.LevelPlayer.text) < _startLevel)
            //  {
            //      _experienceView.LevelPlayer.text = _startLevel.ToString();
            //  }
        
        
        }
    
        void Update()
        {
       
        }

        public void AddExperience(int value)
        {
            // _currentExperience = _playerExperience.PlayerExperience;
            // var newExperience = Mathf.Clamp(value, 0, _experienceView.PlayerExperience.maxValue);
            // OnExperienceChanged?.Invoke( _playerExperience.PlayerExperience += (int) newExperience);
        }

        public void SetExperience(int newExperience)
        {
            StopCoroutine();
        
            if (_currentExperience != newExperience )
            {
                _currentCoroutine = StartCoroutine(UpdateExperience(_currentExperience, newExperience, _animationTime));
                if (_currentExperience >= _experienceView.PlayerExperience.maxValue)
                {
                    LevelUp();
                    _experienceView.PlayerExperience.value -= _experienceView.PlayerExperience.maxValue;
                }
            }
        }
    
        private IEnumerator UpdateExperience(int oldExperience , int newExperience, float animationTime)
        {   
            while (_elapsedTime < animationTime)
            {
                var currentProgress = _elapsedTime / animationTime;
                _currentValue= Mathf.Lerp(oldExperience, newExperience, currentProgress);
                _currentExperience = (int) _currentValue;
                if (_currentExperience >= _experienceView.PlayerExperience.maxValue)
                {
                    LevelUp();
                }
                _experienceView.PlayerExperience.value = _currentExperience;
                _experienceView.ExperienceText.text =_experienceView.PlayerExperience.value + "/" + _experienceView.PlayerExperience.maxValue;
                _elapsedTime += Time.deltaTime;
            
                yield return null;
            }
            _elapsedTime = 0;
            SaveExperienceFields();
        }

        private void LevelUp()
        {
            //   _playerExperience.PlayerExperience -= (int) _experienceView.PlayerExperience.maxValue;
            //   _experienceView.PlayerExperience.maxValue += _experienceView.PlayerExperience.maxValue;
            //   var levelUp = Convert.ToInt32(_experienceView.LevelPlayer.text);
            //   levelUp++;
            //   _experienceView.LevelPlayer.text = levelUp.ToString();
        }
    
        private void StopCoroutine()
        { 
            if (_currentCoroutine != null) 
            {
                StopCoroutine(_currentCoroutine); 
                _currentCoroutine = null;
            }
        }


        private void SaveExperienceFields()
        {
            //   PlayerPrefs.SetInt("PlayerExperience",_playerExperience.PlayerExperience);
            //   PlayerPrefs.SetFloat("MaxValue",_experienceView.PlayerExperience.maxValue);
            //   PlayerPrefs.SetString("LevelPlayer",_experienceView.LevelPlayer.text);
            //   PlayerPrefs.SetFloat("Value",_experienceView.PlayerExperience.value);
        }//

        private void LoadingExperienceFields()
        {
            //   _playerExperience.PlayerExperience = PlayerPrefs.GetInt("PlayerExperience");
            //   _experienceView.PlayerExperience.maxValue = PlayerPrefs.GetFloat("MaxValue");
            //   _experienceView.LevelPlayer.text = PlayerPrefs.GetString("LevelPlayer");
            //   _experienceView.PlayerExperience.value = PlayerPrefs.GetFloat("Value");
            //   if (_experienceView.PlayerExperience.maxValue == 0)
            //   {
            //       _experienceView.PlayerExperience.maxValue = _startMaxValue;
            //       _experienceView.LevelPlayer.text = _startLevel.ToString();
            //   }
        }
    
    
    }
}
