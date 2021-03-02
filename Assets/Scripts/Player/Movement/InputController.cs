using UnityEngine;

public class InputController : MonoBehaviour
{
    public static Vector3 GetDirection()
    {
        return new Vector3(JoystickController.InputDirection.x, 0, JoystickController.InputDirection.y);
    }
}
