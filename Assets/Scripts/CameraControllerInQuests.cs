using UnityEngine;

public class CameraControllerInQuests : MonoBehaviour
{
    // Класс отвечает за передвижение камеры к игроку
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Vector3 _offset;
    
    void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = new Vector3(_player.transform.position.x + _offset.x, _player.transform.position.y + _offset.y,_player.transform.position.z + 
            _offset.z) ;
        }
        
    }
}