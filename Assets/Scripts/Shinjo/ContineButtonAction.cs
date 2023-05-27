using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContineButtonAction : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        objectToActivate.SetActive(true);
    }
}
