using UnityEngine;

public class ApplicationPause : MonoBehaviour
{
    public bool ApplicationPaused { get; private set; }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            ApplicationPauseEvent();
        }

        ApplicationPaused = true;
    }

    private void ApplicationPauseEvent()
    {
        Debug.Log("Application is paused");
    }
}
