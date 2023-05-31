using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage3 : MonoBehaviour
{
    private const float LeftRotationAngle = 176.28f;    // ç∂ë§
    private const float RightRotationAngle = 8f;        // âEë§
    private const float rotationTime = 0.5f;

    public GameObject RotatePage2Object;

    public GameObject RotatePage4Object;

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            RotatePage2Object.GetComponent<RotatePage2>().enabled = false;
            RotatePage4Object.GetComponent<RotatePage4>().enabled = true;
            StartCoroutine(RotateZOverTime(LeftRotationAngle, rotationTime));
        }
        else if (gamepad.dpad.left.wasPressedThisFrame)
        {

            RotatePage4Object.GetComponent<RotatePage4>().enabled = false;
            RotatePage2Object.GetComponent<RotatePage2>().enabled = true;
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
