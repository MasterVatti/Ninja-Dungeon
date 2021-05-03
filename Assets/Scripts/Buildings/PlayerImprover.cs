using BuildingSystem;
using SaveSystem;
using UnityEngine;

namespace Buildings
{
    public class PlayerImprover : Building<PlayerImproverData>
    {
        [SerializeField]
        private int _maxLevel;
        [SerializeField]
        private int _startCost;
        [SerializeField]
        private int _costPerLevelAdjustment;
        
        [Header("State")]
        [SerializeField]
        private int _hpPerPoint;
        [SerializeField]
        private int _attackPerPoint;
        [SerializeField]
        private int _attackSpeedPerPoint;
        [SerializeField]
        private int _movementSpeedPerPoint;
        
        protected override void OnStateLoaded(PlayerImproverData data)
        {
            if (data != null)
            {
                _hpPerPoint = data.HpPerPoint;
                _attackPerPoint = data.AttackPerPoint;
                _attackSpeedPerPoint = data.AttackSpeedPerPoint;
                _movementSpeedPerPoint = data.MovementSpeedPerPoint;
            }
        }

        public override PlayerImproverData GetState()
        {
            return new PlayerImproverData
            {
                AttackPerPoint = _attackPerPoint,
                AttackSpeedPerPoint = _attackSpeedPerPoint,
                HpPerPoint = _hpPerPoint,
                MovementSpeedPerPoint = _movementSpeedPerPoint
            };
        }
    }
}
