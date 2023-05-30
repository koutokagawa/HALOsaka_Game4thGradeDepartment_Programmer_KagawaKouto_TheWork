using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstbuttonAction : MonoBehaviour
{
    [SerializeField] private GameObject objectsToDeactivate;
    [SerializeField] private GameObject stageSelectCube;

    // ÉJÉÅÉâéQè∆
    [SerializeField] private Camera mainCamera;

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        var triggerScaleAndCameraMove = mainCamera.GetComponent<AutoTriggerScaleAndCameraMove>();
        triggerScaleAndCameraMove.enabled = true;

        objectsToDeactivate.SetActive(false);
    }

}
