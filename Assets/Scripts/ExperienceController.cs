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
    
    private int _currentExperience;
    private float _currentValue;
    private Coroutine _currentCoroutine;
    private float _elapsedTime;
    private Characteristics.PlayerCharacteristics _playerExperience;
    private ExperienceView _experienceView;
    private int _newExperience;


    void Start()
    {
        _experienceView.PlayerExperience.maxValue = 100;
    }
    
    void Update()
    {
        _currentExperience = _playerExperience.PlayerExperience;
    }

    public void AddExperience(int value)
    {
        _newExperience = _playerExperience.PlayerExperience += value;
        OnExperienceChanged?.Invoke(_newExperience);
    }

    public void SetExperience(int newExperience)
    {
        StopCoroutine();
        if (_currentExperience != newExperience)
        {
            _currentCoroutine = StartCoroutine(UpdateExperience(_currentExperience, newExperience, _animationTime));
            if (_currentExperience >= _experienceView.PlayerExperience.maxValue)
            {
                LevelUp();
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
        _elapsedTime = 0;
    }

    private void LevelUp()
    {
        _experienceView.PlayerExperience.minValue = _experienceView.PlayerExperience.maxValue;
        _experienceView.PlayerExperience.maxValue += _experienceView.PlayerExperience.maxValue;
        var levelUp = Convert.ToInt32(_experienceView.LevelPlayer.text);
        _experienceView.LevelPlayer.text = (levelUp ++).ToString();
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
