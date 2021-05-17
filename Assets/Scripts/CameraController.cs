using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Класс отвечает за передвижение камеры в подземелье
    
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Vector3 _offset;
    
    void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z + _offset.z);
        }
    }
}