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
        // Zボタンを押すと現在のシーンをリロードする
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // F1と１ボタンを押すとシーンをロード
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("stage1-1");
        }

        // F1と2ボタンを押すとシーンをロード
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("stage2-1");
        }

        // F1と3ボタンを押すとシーンをロード
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("stage3-1");
        }

        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("stage4-1");
        }

        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("stage5-1");
        }
    }
}
