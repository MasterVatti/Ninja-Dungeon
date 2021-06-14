using UnityEngine;

public interface IMovementBehavior
{
    public void MoveToDestination();
    public void SetMoveDestination(Vector3 movePoint);
}
