using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class ExperienceView : MonoBehaviour
{
    // Класс отвечает за UI уровня
    
    public TextMeshProUGUI LevelPlayer
    {
        get => _levelPlayer;
        set => _levelPlayer = value;
    }
    
    public Slider PlayerExperience
    {
        get => _playerExperience;
        set => _playerExperience = value;
    }
    
    public TextMeshProUGUI ExperienceText
    {
        get => _experienceText;
        set => _experienceText = value;
    }
    [SerializeField] 
    private TextMeshProUGUI _levelPlayer;
    [SerializeField] 
    private Slider _playerExperience;
    [SerializeField] 
    private TextMeshProUGUI _experienceText;
    [SerializeField]
    private ExperienceController _experienceController;
    void Start()
    {
        ExperienceController.OnExperienceChanged += OnExperienceChanged;
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            _experienceController.AddExperience(10);
        }
    }
    
    private void OnExperienceChanged(int newExperience)
    {
        _experienceController.SetExperience(newExperience);
    }
    
    private void OnDestroy()
    {
        ExperienceController.OnExperienceChanged -= OnExperienceChanged;
    }
    
    
    
    
}

