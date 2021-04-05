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
    void Update()
    {
        transform.position = _targetToFollow.position + _offset;
    }
}
