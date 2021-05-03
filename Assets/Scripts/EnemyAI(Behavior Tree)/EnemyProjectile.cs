using Assets.Scripts;
using UnityEngine;

/// <summary>
/// Пуля врагов 
/// </summary>
public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] 
    private int _damage;
    
    [SerializeField]
    private float _timeToRemove = 5f;
    
    private void Awake()
    {
        Destroy(gameObject, _timeToRemove);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            Destroy(gameObject);
        }
    }
}
