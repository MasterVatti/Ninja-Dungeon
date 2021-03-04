using UnityEngine;

/// <summary>
/// Этот класс отвечает за передачу направления движения
/// </summary>
public class InputController : MonoBehaviour
{
    public static Vector3 GetDirection()
    {
        return new Vector3(JoystickController.InputDirection.x, 0, JoystickController.InputDirection.y);
    }
}
