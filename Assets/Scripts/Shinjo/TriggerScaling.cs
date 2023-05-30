using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerScaling : MonoBehaviour
{
    // ScaleXOverTime スクリプトを参照する
    public GameObject objectToActivate;
    public GameObject objectToScaleLeft;
    public GameObject objectToScaleRight;

    private int finishedScalingCount = 0;


    // Update is called once per frame
    private void Update()
    {
        // スタートボタンが押されたら、ScaleXOverTimeのBeginScalingを呼び出し、スケーリングを開始する
        if (Gamepad.current.startButton.wasPressedThisFrame)
        {
            // オブジェクトの左右のScaleXOverTimeスクリプトを有効化して実行
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
