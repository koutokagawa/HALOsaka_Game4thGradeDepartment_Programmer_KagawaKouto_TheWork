using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage4 : MonoBehaviour
{
    private const float LeftRotationAngle = 176f;
    private const float RightRotationAngle = 7.9f;
    private const float rotationTime = 0.5f;

    public GameObject RotatePage3Object; // RotatePage3�I�u�W�F�N�g�ւ̎Q�Ƃ�ǉ�
    private bool isRotatePage3Enabled; // RotatePage3�X�N���v�g�̏�Ԃ�ǐՂ��邽�߂̃u�[���ϐ���ǉ�

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
            // �X�N���v�g��RightRotationAngle = 8.1f�̏�Ԃō��{�^���������ꂽ�ꍇ�A�X�N���v�g�𖳌���
            if (Mathf.Abs(transform.eulerAngles.z - RightRotationAngle) < 0.01f)
            {
                this.enabled = false;
                return;
            }

            StartCoroutine(RotateZOverTime(RightRotationAngle, rotationTime));
        }

        // 8.1�x�̂Ƃ��ARotatePage3�X�N���v�g��L����
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