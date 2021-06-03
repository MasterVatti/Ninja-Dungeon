using UnityEngine;

public interface IMovementBehavior
{
    public void MoveToDestination();
    public void MoveTo(Vector3 movePoint);
    public void CheckMoveDestination(Vector3 movePoint);
}
