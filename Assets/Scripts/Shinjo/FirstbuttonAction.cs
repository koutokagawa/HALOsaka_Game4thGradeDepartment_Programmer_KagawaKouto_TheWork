using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FirstbuttonAction : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate;
    [SerializeField] private GameObject[] objectsToDeactivate;
    [SerializeField] private GameObject stageSelectCube;

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        SetActiveStatus(objectsToActivate, true);
        SetActiveStatus(objectsToDeactivate, false);
        stageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
    }

    private void SetActiveStatus(GameObject[] objects, bool status)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(status);
        }
    }
}
