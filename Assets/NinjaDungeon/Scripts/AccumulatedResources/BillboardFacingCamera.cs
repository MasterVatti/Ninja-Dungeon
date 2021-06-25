using UnityEngine;

public class BillboardFacingCamera : MonoBehaviour
{
    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        var mainCamera = Camera.main;
        var vectorToCamera = mainCamera.transform.position - transform.position;
        transform.LookAt(transform.position - vectorToCamera);
    }
}