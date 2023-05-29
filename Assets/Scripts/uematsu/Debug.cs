using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Debug : MonoBehaviour
{
  
    internal static void Log(string v)
    {
        //throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Z�{�^���������ƌ��݂̃V�[���������[�h����
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // F1�ƂP�{�^���������ƃV�[�������[�h
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("stage1-1");
        }

        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("stage1-2");
        }

        // F1��2�{�^���������ƃV�[�������[�h
        if (Input.GetKey(KeyCode.F2) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("stage2-1");
        }

        // F1��3�{�^���������ƃV�[�������[�h
        if (Input.GetKey(KeyCode.F3) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("stage3-1");
        }

        if (Input.GetKey(KeyCode.F4) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("stage4-1");
        }

        if (Input.GetKey(KeyCode.F5) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("stage5-1");
        }
    }
}
