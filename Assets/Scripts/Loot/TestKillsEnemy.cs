using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class TestKillsEnemy : Enemies.Enemy
{
    public event Action EnemyDie;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            EnemyDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
