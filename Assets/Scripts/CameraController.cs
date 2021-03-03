using UnityEngine;

/// <summary>
/// Этот класс отвечает за слежение камеры за игроком
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _targetToFollow;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float _speed;

    private void Update()
    {
        transform.position =
            Vector3.Lerp(transform.position,
                _targetToFollow.position + _offset, Time.deltaTime * _speed);
    }
}
