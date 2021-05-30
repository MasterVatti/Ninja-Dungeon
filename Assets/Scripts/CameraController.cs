using UnityEngine;

/// <summary>
/// Класс отвечает за передвижение камеры в подземелье
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _offset;
    
    private void LateUpdate()
    {
        var player =  MainManager.Player;
        if (player != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + _offset.z);
        }
    }
}