using BuildingSystem;
using SaveSystem;
using UnityEngine;

namespace Buildings
{
    public class PlayerImprover : Building<PlayerImproverData>
    {
        public int HpPerPoint => _hpPerPoint;
        public int AttackPerPoint => _attackPerPoint;
        public float AttackSpeedPerPoint => _attackSpeedPerPoint;
        public float MovementSpeedPerPoint => _movementSpeedPerPoint;
        
        [SerializeField]
        private int _hpPerPoint;
        [SerializeField]
        private int _attackPerPoint;
        [SerializeField]
        private float _attackSpeedPerPoint;
        [SerializeField]
        private float _movementSpeedPerPoint;
        
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
