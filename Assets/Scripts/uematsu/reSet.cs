using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reSet : MonoBehaviour
{
    internal static void Log(string v)
    {
        //throw new NotImplementedException();
    }

    private float count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Trigger = Input.GetAxis("LRtrigger");
        if (Trigger < 0)
        {
            count += Time.deltaTime; // �o�ߎ��Ԃ��v�Z
        }
        // �o�ߎ��Ԃ��߂����烊�Z�b�g
        if (count > 1.5f)//1.5f
        {
            count = 0.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
