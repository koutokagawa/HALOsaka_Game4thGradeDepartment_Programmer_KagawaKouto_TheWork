using System.Collections;
using UnityEngine;

public class TimeLightOn : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public CameraController cameraController; // 追加: CameraControllerへの参照
    private int repeatCount;

    private void Start()
    {
        repeatCount = objectsToActivate.Length;
        StartCoroutine(PerformActionWithDelay());
    }

    private IEnumerator PerformActionWithDelay()
    {
        yield return new WaitForSeconds(1f); // 1秒後に開始

        for (int i = 0; i < repeatCount; i++)
        {
            // オブジェクトを有効化
            objectsToActivate[i].SetActive(true);
            //Debug.Log("オブジェクト" + (i + 1) + "を有効化");

            if (i < repeatCount - 1)
            {
                yield return new WaitForSeconds(1f); // 次のオブジェクトを有効化するまで1秒待機
            }
        }

        yield return new WaitForSeconds(1f); // 追加: すべてのオブジェクトが有効化された後、1秒待機

        // 追加: 1秒後にカメラを後ろに動かします
        cameraController.StartCameraMove();
    }
}
