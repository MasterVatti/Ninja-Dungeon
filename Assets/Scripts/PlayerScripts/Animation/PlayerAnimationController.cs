using System.Collections;
using System.Collections.Generic;
using PlayerScripts.Movement;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
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
            _animator.SetBool("isWalk",true);
        }
        else
        {
            _animator.SetBool("isWalk",false);
        }
    }
}
