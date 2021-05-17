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
            #if UNITY_EDITOR
            var x = Input.GetAxis("Vertical");
            var y = Input.GetAxis("Horizontal");
            return new Vector3(x, 0, y);
            #else
            var inputDirection = MainManager.JoystickController.InputDirection;
            return new Vector3(inputDirection.x, 0, inputDirection.y);
            #endif
        }
    }
}
