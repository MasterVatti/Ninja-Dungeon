using UnityEngine;

public interface IMovementBehavior
{
    public void MoveTo(Vector3 movePoint);
    public void CheckMoveDestination(Vector3 movePoint);
}
