using Panda;
using UnityEngine;

namespace Magician
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
    
        private bool _isGolemCreate;
    
        [Task]
        private bool GolemSpawn()
        {
            if (!_isGolemCreate)
            {
                var golem = Instantiate(_golemPrefab, gameObject.transform.position, Quaternion.identity);
                _isGolemCreate = true;
            }

            return false;
        }
    
        [Task]
        private void GetRunBackPoint()
        {
            _unit.SetColor(Color.green);

            _unit.ChangePointMovement(gameObject.transform.TransformPoint(0, 0, 0 - _runBackDistance));

            Task.current.Succeed();
        }
    }
}
