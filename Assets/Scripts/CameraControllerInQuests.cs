using UnityEngine;

public class CameraControllerInQuests : MonoBehaviour
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
            transform.position = _player.transform.position + _offset ;
        }
    }
}