using System;
using System.Collections;
using System.Collections.Generic;
using Nodes;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float _startingHealth;
    [SerializeField]
    private float _lowHealthThreshold;
    
    [SerializeField]
    private float _shootingRange;
    [SerializeField]
    private Transform _playerTransform;
    
    [SerializeField]
    private GameObject _golemPrefab;
    
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private int _sequenceShots;
    [SerializeField]
    private float _shotCooldownTime = 0.5f;
    private float _nextShotTime;
    
    
    
    
    
    
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _startingHealth;
    }


    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
    
    public void GolemCreate()
    {
        var golem = Instantiate(_golemPrefab,gameObject.transform.position, Quaternion.identity);
    }
    public void Shot()
    {
        for (var i = 0; i < _sequenceShots && Time.time > _nextShotTime; i++)
        {
            _nextShotTime = Time.time + _shotCooldownTime;
            // Додумать более правильную механику стрельбы
            gameObject.transform.LookAt(_playerTransform);
            
            //Если будет оружие сдееллать инстантейтить от него
            var newBullet = Instantiate (_bulletPrefab, gameObject.transform.position,
                gameObject.transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * _bulletSpeed;
        }
    }
    
}
