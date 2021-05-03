using Panda;
using UnityEngine;

namespace MagicianFolder
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) мага (пока спавн голема и отбегание).
    /// </summary>
    public class MagicianAI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _golemPrefab;
        [SerializeField]
        private Unit _unit;
        [SerializeField]
        private float _runBackDistance;
        [SerializeField]
        private Magician _magician;
        [SerializeField]
        private float _lowHealthThreshold;

        private bool _isGolemCreated;

        [Task]
        private void GolemSpawn()
        {
            if (!_isGolemCreated)
            {
                Instantiate(_golemPrefab, gameObject.transform.position, Quaternion.identity);
                _isGolemCreated = true;

                Task.current.Succeed();
            }

            Task.current.Fail();
        }

        [Task]
        private void SetBackPoint()
        {
            _unit.ChangePointMovement(gameObject.transform.TransformPoint(0, 0, 0 - _runBackDistance));
            Task.current.Succeed();
        }

        [Task]
        private bool IsTimeToSpawnGolem()
        {
            return _magician.CurrentHp <= _lowHealthThreshold;
        }
    }
}