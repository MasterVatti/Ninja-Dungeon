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
    
    private int _reboundNumber;
        
    public void Initialize(Vector3 direction)
    {
        _rigidbody.velocity = direction * _projectileSpeed;
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
