using UnityEngine;

public class SomeObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Application.quitting += OnApplicationQuitting;
    }

    private void OnApplicationQuitting()
    {
        // This method will be called when the application is about to quit
        Debug.Log("Application is quitting, doing some cleanup");
        // Do your cleanup here if necessary
    }

    private void OnDestroy()
    {
        // Remember to remove the event listener when this object is destroyed
        Application.quitting -= OnApplicationQuitting;
    }
}
