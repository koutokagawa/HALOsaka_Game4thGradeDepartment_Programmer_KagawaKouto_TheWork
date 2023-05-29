using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePage2 : MonoBehaviour
{
    private const float LeftRotationAngle = 176.55f;  // ����]�̖ڕW�p�x
    private const float RightRotationAngle = 7.82f;   // �E��]�̖ڕW�p�x
    private const float rotationTime = 0.5f;          // ��]�ɂ����鎞��

    public GameObject RotatePage3Object;  // RotatePage3�I�u�W�F�N�g�ւ̎Q��
    private bool isRotatePage3Enabled;    // RotatePage3�X�N���v�g�̏�Ԃ�ǐՂ��邽�߂̃u�[���ϐ�

    void Update()
    {
        if (!this.enabled)
            return;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            // �����X�N���v�g������]�p�x(176.55�x)�ɂ���Ƃ��ɉE�{�^�����ēx�����ꂽ��ARotatePage2�X�N���v�g�𖳌��ɂ���
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

        // 176.55�x�ɂȂ�����ARotatePage3�X�N���v�g��L���ɂ���
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
