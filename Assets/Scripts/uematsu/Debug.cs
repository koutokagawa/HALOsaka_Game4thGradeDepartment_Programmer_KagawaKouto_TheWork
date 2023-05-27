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
            SceneManager.LoadScene("game uematsu");
        }

        // F1と2ボタンを押すとシーンをロード
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha2))
        {
            //SceneManager.LoadScene("ここにシーン名を書く");
        }

        // F1と3ボタンを押すとシーンをロード
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.Alpha3))
        {
            //SceneManager.LoadScene("ここにシーン名を書く");
        }
    }
}
