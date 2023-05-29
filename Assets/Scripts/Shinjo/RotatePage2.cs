using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage2 : MonoBehaviour
{
    private const float LeftRotationAngle = 176.55f;  // 左回転の目標角度
    private const float RightRotationAngle = 7.82f;   // 右回転の目標角度
    private const float rotationTime = 0.5f;          // 回転にかかる時間

    public GameObject RotatePage3Object;  // RotatePage3オブジェクトへの参照
    private bool isRotatePage3Enabled;    // RotatePage3スクリプトの状態を追跡するためのブール変数

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            // もしスクリプトが左回転角度(176.55度)にいるときに右ボタンが再度押されたら、RotatePage2スクリプトを無効にする
            if (Mathf.Abs(transform.eulerAngles.z - LeftRotationAngle) < 0.01f)
            {
                this.enabled = false;
                return;
            }

            StartCoroutine(RotateZOverTime(LeftRotationAngle, rotationTime));
        }
        else if (gamepad.dpad.left.wasPressedThisFrame)
        {
            if (Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
            {
                RotatePage3Object.GetComponent<RotatePage3>().enabled = false;
                isRotatePage3Enabled = false;
                return;
            }

            StartCoroutine(RotateZOverTime(RightRotationAngle, rotationTime));
        }

        // 176.55度になったら、RotatePage3スクリプトを有効にする
        if (!isRotatePage3Enabled && Mathf.Abs(transform.eulerAngles.z - LeftRotationAngle) < 0.01f)
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
