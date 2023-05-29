using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(11.6f, 23.4f, 78.3f);
    private float moveDuration = 1f;

    public void MoveToPosition()
    {
        StartCoroutine(MoveCameraToPosition());
    }

    private IEnumerator MoveCameraToPosition()
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
