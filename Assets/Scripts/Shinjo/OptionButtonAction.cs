using UnityEngine;
using UnityEngine.UI;

public class OptionButtonAction : MonoBehaviour
{
    public Button scaleButton;
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;
    public GameObject objectToScaleLeft;
    public GameObject objectToScaleRight;

    private int finishedScalingCount = 0;

    private void Start()
    {
        scaleButton.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        objectToDeactivate.SetActive(false);

        // �I�u�W�F�N�g�̍��E��ScaleXOverTime�X�N���v�g��L�������Ď��s
        EnableAndRunScaleScript(objectToScaleLeft, true);
        EnableAndRunScaleScript(objectToScaleRight, true);
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
