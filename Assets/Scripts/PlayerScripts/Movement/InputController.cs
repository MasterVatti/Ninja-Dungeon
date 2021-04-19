using UnityEngine;
namespace PlayerScripts.Movement
{
    /// <summary>
    /// Этот класс отвечает за передачу направления движения
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public static Vector3 GetDirection()
        {
            var inputDirection = MainManager.JoystickController.InputDirection;
            return new Vector3(inputDirection.x, 0, inputDirection.y);
        }
    }
}
