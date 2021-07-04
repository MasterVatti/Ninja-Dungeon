using Characteristics;
using JetBrains.Annotations;
using UnityEngine;

namespace PlayerScripts.Movement
{
    /// <summary>
    /// Этот класс отвечает за перемещения игрока в пространстве
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _player;
        [SerializeField]
        private float _rotationSpeed = 0.5f;

        [UsedImplicitly]
        private Quaternion _playerStartRotation;

        private PlayerCharacteristics _playerCharacteristics;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            //   MainManager.JoystickController.OnJoystickDown += JoystickDownHandler;

            _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        }

        private void JoystickDownHandler()
        {
            _playerStartRotation = _player.transform.rotation;
        }

        private void OnDestroy()
        {
            //  if (MainManager.JoystickController)
            // {
            //      MainManager.JoystickController.OnJoystickDown -= JoystickDownHandler;
            // }
        }

        private void Update()
        {
            if (!_playerCharacteristics.CanMove)
            {
                return;
            }

            var inputDirection = InputController.GetDirection();

            #if UNITY_EDITOR
            transform.rotation = Quaternion.Euler(0,
                transform.rotation.eulerAngles.y + inputDirection.z * _rotationSpeed,
                0);
            _player.velocity = transform.forward * (_playerCharacteristics.MoveSpeed * inputDirection.x);
            #else
            _player.velocity = _playerStartRotation * inputDirection * _speed;

            var direction = _player.velocity;
            if (!direction.Equals(Vector3.zero))
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
             #endif
        }
    }
}