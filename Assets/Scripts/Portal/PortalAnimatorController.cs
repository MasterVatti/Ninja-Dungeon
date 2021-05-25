using UnityEngine;

public class PortalAnimatorController
{
    private readonly Animator _animator;
    
    private static readonly int HasEnoughEnergy = Animator.StringToHash("HasEnoughEnergy");
    
    public PortalAnimatorController(Animator animator)
    {
        _animator = animator;
    }

    public void ChangeButtonColor(bool hasEnoughEnergy)
    {
        _animator.SetBool(HasEnoughEnergy, hasEnoughEnergy);
    }
}
