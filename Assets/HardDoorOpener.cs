using UnityEngine;

public class HardDoorOpener : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private GameObject _closedUI;
    [SerializeField]
    private GameObject _openedUI;
    
    private void Start()
    {
        // if (последняя комната второй двери пройдена)
        // {
        //     _closedUI.gameObject.SetActive(false);
        //     _openedUI.gameObject.SetActive(true);
        //     _collider.gameObject.SetActive(true);
        // }
    }
}