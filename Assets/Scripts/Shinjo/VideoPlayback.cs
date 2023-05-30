using UnityEngine;
using UnityEngine.Video;

public class VideoPlayback : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // �r�f�I�v���C���[�R���|�[�l���g
    public GameObject scriptToobject;

    void Start()
    {
        // �r�f�I���I�������Ƃ��ɌĂяo����郁�\�b�h��o�^���܂�
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // �r�f�I���I�������Ƃ��ɌĂяo����郁�\�b�h
    void OnVideoFinished(VideoPlayer vp)
    {
        // Script��L���ɂ��܂�
        scriptToobject.GetComponent<TriggerScaleAndCameraMove>().enabled = true;
    }
}
