using System;
using Characteristics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaDungeon.Scripts.HealthBarSystem
{
    public class PersonHealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider _healthBarSlider;

        [SerializeField]
        private TextMeshProUGUI _currentHealth;

        private PersonCharacteristics _personCharacteristics;
        private int _lastHp = Int32.MinValue;
        private RectTransform _transform;
        private RectTransform _parent;

        private void Awake()
        {
            _healthBarSlider.interactable = false;
            _transform = transform as RectTransform;
            _parent = _transform.parent as RectTransform;
        }

        public void Initialize(Person person)
        {
            _personCharacteristics = person.PersonCharacteristics;
        }

        private void Update()
        {
            _transform.anchoredPosition = UIUtility.WorldToCanvasPosition(_parent, _personCharacteristics.transform);
            
            if (_personCharacteristics != null && _lastHp != _personCharacteristics.CurrentHp)
            {
                _currentHealth.text = $"{_personCharacteristics.CurrentHp} / " +
                                      $"{_personCharacteristics.MaxHp}";
                
                _healthBarSlider.value = (float) _personCharacteristics.CurrentHp / _personCharacteristics.MaxHp;

                _lastHp = _personCharacteristics.CurrentHp;
            }
        }
    }
}