using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    // Класс Отвечает за логику начисления опыта
    public static event Action<int> OnExperienceChanged;
    
    [SerializeField] 
    private float _animationTime;
    [SerializeField]
    private Characteristics.PlayerCharacteristics _playerExperience;
    [SerializeField]
    private ExperienceView _experienceView;
    
    private int _currentExperience;
    private float _currentValue;
    private float _elapsedTime;
    private int _newExperience;
    private Coroutine _currentCoroutine;
    private string _currentLevelPlayer;

    void Start()
    {
        _experienceView.LevelPlayer.text = "1";
        _currentLevelPlayer =_experienceView.LevelPlayer.text;
    }
    
    void Update()
    {
        
    }

    public void AddExperience(int value)
    {
        _currentExperience = _playerExperience.PlayerExperience;
        OnExperienceChanged?.Invoke( _playerExperience.PlayerExperience += value);
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
            _experienceView.PlayerExperience.value = _currentExperience;
            _experienceView.ExperienceText.text =_experienceView.PlayerExperience.value + "/" + _experienceView.PlayerExperience.maxValue;
            _elapsedTime += Time.deltaTime;
            

            yield return null;
        }
        if (_currentExperience >= _experienceView.PlayerExperience.maxValue)
        {
            LevelUp();
        }
        
        _elapsedTime = 0;
    }

    private void LevelUp()
    {
        _playerExperience.PlayerExperience -= (int) _experienceView.PlayerExperience.maxValue;
        _experienceView.PlayerExperience.maxValue += _experienceView.PlayerExperience.maxValue;
        var levelUp = Convert.ToInt32(_experienceView.LevelPlayer.text);
        levelUp++;
        _experienceView.LevelPlayer.text = levelUp.ToString();
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
        
    }
    
    
}
