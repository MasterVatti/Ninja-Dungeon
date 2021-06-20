using UnityEngine;

public class MediumDoorOpener : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private GameObject _closedUI;
    [SerializeField]
    private GameObject _openedUI;
    
    private void Start()
    {
        // if (последняя комната первой двери пройдена)
        // {
        //     _closedUI.gameObject.SetActive(false);
        //     _openedUI.gameObject.SetActive(true);
        //     _collider.gameObject.SetActive(true);
        // }
    }
}
