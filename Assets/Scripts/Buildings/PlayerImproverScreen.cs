using Characteristics;
using TMPro;
using UnityEngine;

namespace Buildings
{
    public class PlayerImproverScreen : MonoBehaviour
    {
        [SerializeField]
        private PlayerCharacteristics _playerCharacteristics;
        [SerializeField]
        private PlayerImprover _playerImprover;

        [Header("Labels")]
        [SerializeField]
        private TextMeshPro _hpLabel;
        [SerializeField]
        private TextMeshPro _attackLabel;
        [SerializeField]
        private TextMeshPro _attackSpeedLabel;
        [SerializeField]
        private TextMeshPro _movementSpeedLabel;

        private void Start()
        {
            UpdateLabels();
        }

        public void AddHp()
        {
            _playerCharacteristics.MaxHp += _playerImprover.HpPerPoint;
            UpdateLabels();
        }

        public void SubtractHp()
        {
            _playerCharacteristics.MaxHp -= _playerImprover.HpPerPoint;
            UpdateLabels();
        }

        public void AddAttack()
        {
            _playerCharacteristics.AttackDamage += _playerImprover.AttackPerPoint;
            UpdateLabels();
        }

        public void SubtractAttack()
        {
            _playerCharacteristics.AttackDamage -= _playerImprover.AttackPerPoint;
            UpdateLabels();
        }

        public void AddAttackSpeed()
        {
            _playerCharacteristics.AttackRate += _playerImprover.AttackSpeedPerPoint;
            UpdateLabels();
        }

        public void SubtractAttackSpeed()
        {
            _playerCharacteristics.AttackRate -= _playerImprover.AttackSpeedPerPoint;
            UpdateLabels();
        }

        public void AddMovementSpeed()
        {
            _playerCharacteristics.MoveSpeed += _playerImprover.MovementSpeedPerPoint;
            UpdateLabels();
        }

        public void SubtractMovementSpeed()
        {
            _playerCharacteristics.MoveSpeed -= _playerImprover.MovementSpeedPerPoint;
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            _hpLabel.text = _playerCharacteristics.MaxHp.ToString();
            _attackLabel.text = _playerCharacteristics.AttackDamage.ToString();
            _attackSpeedLabel.text = _playerCharacteristics.AttackRate.ToString();
            _movementSpeedLabel.text = _playerCharacteristics.MoveSpeed.ToString();
        }
    }
}
