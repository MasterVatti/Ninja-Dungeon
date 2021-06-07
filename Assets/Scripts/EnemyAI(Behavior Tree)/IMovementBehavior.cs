using UnityEngine;

public interface IMovementBehavior
{
    public void MoveToDestination();
    public void MoveTo(Vector3 movePoint);
    public void SetMoveDestination(Vector3 movePoint);
}
