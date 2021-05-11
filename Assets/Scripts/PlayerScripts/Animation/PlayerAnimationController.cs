using PlayerScripts.Movement;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        RunningAnimation();
    }

    private void RunningAnimation()
    {
        var direction = InputController.GetDirection();
        if (direction.x != 0 || direction.z != 0)
        {
            _animator.SetBool(IsWalk,true);
        }
        else
        {
            _animator.SetBool(IsWalk,false);
        }
    }
}
