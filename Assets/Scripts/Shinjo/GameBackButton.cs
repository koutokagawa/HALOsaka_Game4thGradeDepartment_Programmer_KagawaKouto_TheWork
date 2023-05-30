using UnityEngine;
using UnityEngine.UI;

public class GameBackButton : MonoBehaviour
{
    public Button backButton;
    public GameObject objectToDeactivate;
    public GameObject objectToScaleLeft;
    public GameObject objectToScaleRight;

    private int finishedScalingCount = 0;

    private void Start()
    {
        backButton.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        //Time.timeScale = 1;
        objectToDeactivate.SetActive(false);

        // オブジェクトの左右のScaleXOverTimeスクリプトを有効化して実行
        EnableAndRunScaleScript(objectToScaleLeft, false);
        EnableAndRunScaleScript(objectToScaleRight, false);
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
            
        }
    }
}