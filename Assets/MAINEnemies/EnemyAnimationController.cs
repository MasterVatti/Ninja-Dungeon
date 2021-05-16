using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Unit _unit;
    
    private static readonly int StayOnPlace = Animator.StringToHash("StayOnPlace");

    private void Start()
    {
        _unit = GetComponent<Unit>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_unit.IsWalk)
        {
            _animator.SetBool(StayOnPlace, true);
        }
        else
        {
            _animator.SetBool(StayOnPlace, false);
        }
    }
}
