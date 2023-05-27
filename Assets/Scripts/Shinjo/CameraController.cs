using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1.0f;
    [SerializeField] private float moveDuration = 1.0f;

    public void MoveCameraBack()
    {
        StartCoroutine(MoveCameraBackCoroutine());
    }

    private IEnumerator MoveCameraBackCoroutine()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + (-transform.forward * moveDistance);
        float elapsedTime = 0.0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            yield return null;
        }
    }

    // 他のスクリプトからこのメソッドを呼び出すことで、カメラが後ろに移動するタイミングを制御できます
    public void StartCameraMove()
    {
        MoveCameraBack();
    }
}
