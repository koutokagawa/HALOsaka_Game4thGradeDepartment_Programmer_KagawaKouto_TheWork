using System.Diagnostics;
using UnityEngine;

public class DeletScreen : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject Screen;

    private void Update()
    {
        // �I�u�W�F�N�g�̃A�N�e�B�u��Ԃ��m�F����
        bool isActive = targetObject.activeSelf;

        if (isActive)
        {
            Screen.gameObject.SetActive(true);
        }
        else
        {
            Screen.gameObject.SetActive(false);
        }
    }
}