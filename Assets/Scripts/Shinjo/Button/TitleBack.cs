using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBack : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void Awake()
    {
        enabled = false;
    }
    public void ButtonClicked()
    {
        objectToActivate.SetActive(true);
    }
    
}