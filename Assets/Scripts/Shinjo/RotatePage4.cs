using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage4 : MonoBehaviour
{
    private const float LeftRotationAngle = 176f;
    private const float RightRotationAngle = 7.9f;
    private const float rotationTime = 0.5f;

    public GameObject RotatePage3Object; // RotatePage3オブジェクトへの参照を追加
    private bool isRotatePage3Enabled; // RotatePage3スクリプトの状態を追跡するためのブール変数を追加

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
        }
        else if (gamepad.dpad.left.wasPressedThisFrame)
        {
            // スクリプトがRightRotationAngle = 8.1fの状態で左ボタンが押された場合、スクリプトを無効化
            if (Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
            {
                this.enabled = false;
                return;
            }

            StartCoroutine(RotateZOverTime(RightRotationAngle, rotationTime));
        }

        // 8.1度のとき、RotatePage3スクリプトを有効化
        if (!isRotatePage3Enabled && Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
        {
            RotatePage3Object.GetComponent<RotatePage3>().enabled = true;
            isRotatePage3Enabled = true;
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