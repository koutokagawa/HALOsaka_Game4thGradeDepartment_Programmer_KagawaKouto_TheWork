using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayback : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // VideoPlayer component
    public GameObject objectToEnable;  // The 3D object to enable after video has finished

    void Start()
    {
        // Disable the object at start
        objectToEnable.SetActive(false);

        // Add listener for when the video finishes playing
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Enable the object when the video has finished
        objectToEnable.SetActive(true);
    }
}
