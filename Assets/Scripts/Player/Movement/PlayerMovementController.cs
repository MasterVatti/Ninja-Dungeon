using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0F;
    [SerializeField]
    private Rigidbody _player;

    void Update()
    {
        _player.velocity = InputController.GetDirection() * _speed;
    }
}
