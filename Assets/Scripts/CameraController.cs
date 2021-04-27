using UnityEngine;

/// <summary>
/// Этот класс отвечает за слежение камеры за игроком
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Vector3 _offset; 

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private float _speed;

    private Quaternion _lastRotation;

    private void Update()
    {
        var targetPosition = _target.transform.position - _target.transform.rotation * _offset;
        var targetRotation = Quaternion.LookRotation(_target.transform.position - _camera.transform.position, Vector3.up);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, Time.deltaTime * _speed);
        _camera.transform.rotation = Quaternion.Slerp(_camera.transform.rotation, targetRotation, Time.deltaTime * _speed);
    }
}