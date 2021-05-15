using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private EnemiesTestPatrol _enemiesTestPatrol;
    
    private static readonly int StayOnPlace = Animator.StringToHash("StayOnPlace");

    private void Start()
    {
        _enemiesTestPatrol = GetComponent<EnemiesTestPatrol>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_enemiesTestPatrol.IsOnPoint == true)
        {
            _animator.SetBool(StayOnPlace, true);
        }
        else
        {
            _animator.SetBool(StayOnPlace, false);
        }
    }
}
