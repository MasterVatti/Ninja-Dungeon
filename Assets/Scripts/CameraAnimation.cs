using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{

    [SerializeField]
    private Animator _bash;

    public void Shake()
    {
        _bash.SetTrigger("Shake");
    }
}
