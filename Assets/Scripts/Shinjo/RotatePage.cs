using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage : MonoBehaviour
{
    private const float LeftRotationAngle = 176.55f;
    private const float RightRotationAngle = 7.82f;
    private const float rotationTime = 0.5f;

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;
    }

    public void RotateLeft()
    {
        StartCoroutine(RotateZOverTime(LeftRotationAngle, rotationTime));
    }

    public void RotateRight()
    {
        StartCoroutine(RotateZOverTime(RightRotationAngle, rotationTime));
    }

    IEnumerator RotateZOverTime(float targetAngle, float duration)
    {
        float startRotation = transform.eulerAngles.z;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = Mathf.Clamp(elapsed / duration, 0, 1);
            float newAngle = Mathf.Lerp(startRotation, targetAngle, normalizedTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newAngle);
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, targetAngle);
    }
}
