using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerScaling : MonoBehaviour
{
    // ScaleXOverTime �X�N���v�g���Q�Ƃ���
    public GameObject objectToActivate;
    public GameObject objectToScaleLeft;
    public GameObject objectToScaleRight;

    private int finishedScalingCount = 0;


    // Update is called once per frame
    private void Update()
    {
        // �X�^�[�g�{�^���������ꂽ��AScaleXOverTime��BeginScaling���Ăяo���A�X�P�[�����O���J�n����
        if (Gamepad.current.startButton.wasPressedThisFrame)
        {
            // �I�u�W�F�N�g�̍��E��ScaleXOverTime�X�N���v�g��L�������Ď��s
            EnableAndRunScaleScript(objectToScaleLeft, true);
            EnableAndRunScaleScript(objectToScaleRight, true);
        }
    }

    private void EnableAndRunScaleScript(GameObject target, bool scaleUp)
    {
        ScaleXOverTime scaleXOverTime = target.GetComponent<ScaleXOverTime>();
        if (scaleXOverTime != null)
        {
            scaleXOverTime.enabled = true;
            scaleXOverTime.BeginScaling(OnScalingFinished, scaleUp);
        }
    }

    private void OnScalingFinished()
    {
        finishedScalingCount++;

        if (finishedScalingCount >= 2)
        {
            objectToActivate.SetActive(true);
        }
    }
}
