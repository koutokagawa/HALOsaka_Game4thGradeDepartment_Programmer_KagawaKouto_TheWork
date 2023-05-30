using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AutoTriggerScaleAndCameraMove : MonoBehaviour
{
    // ScaleXOverTime スクリプトを参照する
    public GameObject objectToScaleLeft;
    public GameObject objectToScaleRight;
    [SerializeField] private GameObject stageSelectCube;


    private int finishedScalingCount = 0;


    // カメラの新しい位置
    private Vector3 newCameraPosition = new Vector3(-0.7f, 27.4f, 106.9f);
    // 移動時間
    private float moveDuration = 2f;
    // カメラ参照
    [SerializeField] private Camera mainCamera;

    private void OnEnable()
    {
        // オブジェクトの左右のScaleXOverTimeスクリプトを有効化して実行
        EnableAndRunScaleScript(objectToScaleLeft, false);
        EnableAndRunScaleScript(objectToScaleRight, false); 
        StartCoroutine(MoveCameraToPosition(mainCamera, newCameraPosition, moveDuration));
    }

    // カメラを指定位置に移動させるコルーチン
    private IEnumerator MoveCameraToPosition(Camera camera, Vector3 newPosition, float duration)
    {
        Vector3 startPosition = camera.transform.position; // 開始位置
        float startTime = Time.time; // 開始時間

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            camera.transform.position = Vector3.Lerp(startPosition, newPosition, t);
            yield return null;
        }

        // 移動完了
        camera.transform.position = newPosition;
    }

    private void EnableAndRunScaleScript(GameObject target, bool scaleUp)
    {
        ScaleXOverTime scaleXOverTime = target.GetComponent<ScaleXOverTime>();
        if (scaleXOverTime != null)
        {
            scaleXOverTime.enabled = true;
            scaleXOverTime.BeginScaling(OnScalingFinished, scaleUp);
        }
    }

    private void OnScalingFinished()
    {
        finishedScalingCount++;

        if (finishedScalingCount >= 2)
        {
            stageSelectCube.SetActive(true);
            stageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
            this.enabled = false;
        }
    }
}
