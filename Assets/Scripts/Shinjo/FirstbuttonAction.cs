using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FirstbuttonAction : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate;
    [SerializeField] private GameObject[] objectsToDeactivate;
    [SerializeField] private GameObject stageSelectCube;
    [SerializeField] private Transform cameraTransform; // reference to the camera's transform

    private Vector3 targetPosition = new Vector3(-0.7f, 27.4f, 106.9f); // target position for the camera

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        SetActiveStatus(objectsToActivate, true);
        SetActiveStatus(objectsToDeactivate, false);
        stageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
        MoveCameraToPosition();
    }

    private void SetActiveStatus(GameObject[] objects, bool status)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(status);
        }
    }

    private void MoveCameraToPosition()
    {
        cameraTransform.position = targetPosition; // move the camera to the target position
    }
}
