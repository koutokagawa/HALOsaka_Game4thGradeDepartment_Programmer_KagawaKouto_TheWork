using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage3 : MonoBehaviour
{
    private const float LeftRotationAngle = 176.28f;
    private const float RightRotationAngle = 8f;
    private const float rotationTime = 0.5f;

    public GameObject RotatePage2Object;
    private bool isRotatePage2Enabled;

    public GameObject RotatePage4Object;
    private bool isRotatePage4Enabled;

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            // スクリプトがLeftRotationAngle = 176.28fの状態で右ボタンが押された場合、RotatePage3スクリプトを無効化
            if (Mathf.Abs(transform.eulerAngles.z - LeftRotationAngle) < 0.01f)
            {
                this.enabled = false;
                return;
            }

            StartCoroutine(RotateZOverTime(LeftRotationAngle, rotationTime));

            // 右ボタンが押されたときにRotatePage2スクリプトを無効化
            if (isRotatePage2Enabled)
            {
                RotatePage2Object.GetComponent<RotatePage2>().enabled = false;
                isRotatePage2Enabled = false;
            }
        }
        else if (gamepad.dpad.left.wasPressedThisFrame)
        {
            // スクリプトがRightRotationAngle = 8fの状態で右ボタンが押された場合、RotatePage3スクリプトを無効化
            if (Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
            {
                this.enabled = false;
                return;
            }


            // スクリプトがRightRotationAngle = 8fの状態で左ボタンが押された場合、スクリプトを無効化
            if (Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
            {
                this.enabled = false;
                RotatePage4Object.GetComponent<RotatePage4>().enabled = false;
                isRotatePage4Enabled = false;
                return;
            }

            StartCoroutine(RotateZOverTime(RightRotationAngle, rotationTime));
        }

        // 8度のとき、RotatePage2スクリプトを有効化
        if (!isRotatePage2Enabled && Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
        {
            RotatePage2Object.GetComponent<RotatePage2>().enabled = true;
            isRotatePage2Enabled = true;
        }

        // 176.28度のとき、RotatePage4スクリプトを有効化
        if (!isRotatePage4Enabled && Mathf.Abs(transform.eulerAngles.z - LeftRotationAngle) < 0.01f)
        {
            RotatePage4Object.GetComponent<RotatePage4>().enabled = true;
            isRotatePage4Enabled = true;
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
