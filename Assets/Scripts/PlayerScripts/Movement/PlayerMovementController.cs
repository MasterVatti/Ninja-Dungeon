using UnityEngine;
namespace PlayerScripts.Movement
{
    /// <summary>
    /// Этот класс отвечает за перемещения игрока в пространстве
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1.0F;
        [SerializeField]
        private Rigidbody _player;

        private Quaternion _playerStartRotation;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            MainManager.JoystickController.OnJoystickDown += JoystickDownHandler;
        }

        private void JoystickDownHandler()
        {
            _playerStartRotation = _player.transform.rotation;
        }

        private void OnDestroy()
        {
            MainManager.JoystickController.OnJoystickDown -= JoystickDownHandler;
        }

        private Vector3 GetGlobalMoveDirection()
        {
            var inputDirection = MainManager.JoystickController.InputDirection;
            return new Vector3(inputDirection.x, 0, inputDirection.y);
        }
        
        private void Update()
        {
            _player.velocity = _playerStartRotation * GetGlobalMoveDirection() * _speed;

            var direction = _player.velocity;
            if (!direction.Equals(Vector3.zero))
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
