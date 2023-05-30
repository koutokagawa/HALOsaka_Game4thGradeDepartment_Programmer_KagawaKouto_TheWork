using UnityEngine;
using UnityEngine.Video;

public class VideoPlayback : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // ビデオプレイヤーコンポーネント
    public GameObject scriptToobject;

    void Start()
    {
        // ビデオが終了したときに呼び出されるメソッドを登録します
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // ビデオが終了したときに呼び出されるメソッド
    void OnVideoFinished(VideoPlayer vp)
    {
        // Scriptを有効にします
        scriptToobject.GetComponent<TriggerScaleAndCameraMove>().enabled = true;
    }
}
