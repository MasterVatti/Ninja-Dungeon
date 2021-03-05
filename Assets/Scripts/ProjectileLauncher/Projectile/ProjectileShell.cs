using UnityEngine;

public class ProjectileShell : MonoBehaviour
{
    /// <summary>
    /// Движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    
    [SerializeField] 
    private float bulletSpeed;
    [SerializeField] 
    private NearestEnemyDetector nearestEnemy;
    [SerializeField] 
    public int damage;
    
    
    private Vector3 _nearestEnemyPosition;
    private Transform _startPosition; 
    
    private void Awake()
    {
        if (gameObject)
        {
            _nearestEnemyPosition = nearestEnemy.nearestEnemyCoords;
            _startPosition = transform;
        }
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
