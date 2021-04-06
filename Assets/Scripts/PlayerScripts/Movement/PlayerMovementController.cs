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

        private void Update()
        {
            _player.velocity = InputController.GetDirection() * _speed;

            var direction = _player.velocity;
            if (!direction.Equals(Vector3.zero))
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
