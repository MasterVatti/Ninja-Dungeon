using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceControlle : MonoBehaviour
{
    // Класс Отвечает за логику начисления опыта
    
    public int MaxExperience
    {
        get => _maxExperience;
        set => _maxExperience = value;
    }
    
    public int CurrentExperience
    {
        get => _currentExperience;
        set => _currentExperience = value;
    }
    
    private int _maxExperience = 100;
    private int _currentExperience;
    private Characteristics.PlayerCharacteristics _playerExperience;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveExperienceFields()
    {
        
    }
    
    
}
