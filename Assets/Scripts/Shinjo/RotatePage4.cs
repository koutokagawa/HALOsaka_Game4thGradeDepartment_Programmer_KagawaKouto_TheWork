using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage4 : MonoBehaviour
{
    private const float LeftRotationAngle = 176f;       // 左側
    private const float RightRotationAngle = 7.9f;      // 右側
    private const float rotationTime = 0.5f;

    public GameObject RotatePage3Object; // RotatePage3オブジェクトへの参照を追加

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            RotatePage3Object.GetComponent<RotatePage3>().enabled = false;

            StartCoroutine(RotateZOverTime(LeftRotationAngle, rotationTime));
        }
        else if (gamepad.dpad.left.wasPressedThisFrame)
        {
            RotatePage3Object.GetComponent<RotatePage3>().enabled = true;
            StartCoroutine(RotateZOverTime(RightRotationAngle, rotationTime));
        }
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