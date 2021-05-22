using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private ExperienceController _experienceController;

    void Start()
    {
        ExperienceController.OnExperienceChanged += OnExperienceChanged;
        _levelPlayer.text = "1";
    }

    void Update()
    {
        if (Input.GetKeyUp("Space"))
        {
            _experienceController.AddExperience(100);
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

