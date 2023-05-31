using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage2 : MonoBehaviour
{
    private const float LeftRotationAngle = 176.55f;  // ����
    private const float RightRotationAngle = 8.43f;   // �E��
    private const float rotationTime = 0.5f;          // ��]�ɂ����鎞��

    public GameObject RotatePage3Object;  // RotatePage3�I�u�W�F�N�g�ւ̎Q��

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            StartCoroutine(RotateZOverTime(LeftRotationAngle, rotationTime));
            RotatePage3Object.GetComponent<RotatePage3>().enabled = true;
        }
        else if (gamepad.dpad.left.wasPressedThisFrame)
        {
            RotatePage3Object.GetComponent<RotatePage3>().enabled = false;
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
