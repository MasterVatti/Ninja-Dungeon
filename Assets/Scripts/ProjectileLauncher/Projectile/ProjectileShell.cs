using UnityEngine;

/// <summary>
/// Движение каждой конкретной пули к ближайшему противнику
/// </summary>

public class ProjectileShell : MonoBehaviour
{
    [SerializeField] 
    private float bulletSpeed;
    [SerializeField] 
    private NearestEnemyDetector enemyDetector;
    [SerializeField] 
    private int damage;
    
    public int Damage => damage;
    
    private Vector3 _nearestEnemyPosition;
    private Transform _startPosition; 
    
    private void Awake()
    {
        _nearestEnemyPosition = enemyDetector.NearestEnemyCoords;
        _startPosition = transform;
    }
    
    private void Update()
    {
        if (gameObject)
        {
            transform.position = Vector3.Lerp(_startPosition.position,
                _nearestEnemyPosition, Time.deltaTime * bulletSpeed);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
