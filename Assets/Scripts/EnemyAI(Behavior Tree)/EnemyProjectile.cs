using Assets.Scripts;
using Enemies;
using UnityEngine;

/// <summary>
/// Пуля врагов 
/// </summary>
public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] 
    private float _projectileSpeed;
    [SerializeField] 
    private int _damage;
    [SerializeField]
    private Rigidbody _rigidbody;
        
    private Vector3 _direction;
    private int _reboundNumber;
        
    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        _rigidbody.velocity = _direction * _projectileSpeed;
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            DealDamage(collision);
            gameObject.SetActive(false);
        }
    }
    
    private void DealDamage(Collision collision)
    {
        var objectHealth = collision.gameObject.GetComponent<HealthBehaviour>();
        objectHealth.ApplyDamage(_damage);
    }
}
