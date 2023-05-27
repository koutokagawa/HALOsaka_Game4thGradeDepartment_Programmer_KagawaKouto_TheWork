using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class Cotcheck : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Aボタン
        if (Input.GetKeyDown("joystick button 0"))
        {
            UnityEngine.Debug.Log("button0");
        }
        // Bボタン
        if (Input.GetKeyDown("joystick button 1"))
        {
            UnityEngine.Debug.Log("button1");
        }
        // Xボタン
        if (Input.GetKeyDown("joystick button 2"))
        {
            UnityEngine.Debug.Log("button2");
        }
        // Yボタン
        if (Input.GetKeyDown("joystick button 3"))
        {
            UnityEngine.Debug.Log("button3");
        }
        
        // LBボタン
        if (Input.GetKeyDown("joystick button 4"))
        {
            UnityEngine.Debug.Log("button4");
        }
        // RBボタン
        if (Input.GetKeyDown("joystick button 5"))
        {
            UnityEngine.Debug.Log("button5");
        }

        // LR
        float Trigger = Input.GetAxis("LRtrigger");
        if (Trigger > 0)
        {
            UnityEngine.Debug.Log("L trigger:" + Trigger);
        }
        else if (Trigger < 0)
        {
            UnityEngine.Debug.Log("R trigger:" + Trigger);
        }
        else
        {
          //  UnityEngine.Debug.Log("  trigger:none");
        }

        // 左のオプションボタン？
        if (Input.GetKeyDown("joystick button 6"))
        {
            UnityEngine.Debug.Log("button6");
        }
        // 右のオプションボタン？
        if (Input.GetKeyDown("joystick button 7"))
        {
            UnityEngine.Debug.Log("button7");
        }
        
        if (Input.GetKeyDown("joystick button 8"))
        {
            UnityEngine.Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            UnityEngine.Debug.Log("button9");
        }

        // 左スティック
        float LstickX = Input.GetAxis("LstickX");
        float LstickY = Input.GetAxis("LstickY");
        if ((LstickX != 0) || (LstickY != 0))
        {
            UnityEngine.Debug.Log("stick:" + LstickX + "," + LstickY);
        }

        // 右スティック        
        float RstickX = Input.GetAxis("RstickX");
        float RstickY = Input.GetAxis("RstickY");
        if ((RstickX != 0) || (RstickY != 0))
        {
            UnityEngine.Debug.Log("stick:" + RstickX + "," + RstickY);
        }

        // 十字ボタン
        float DpadX = Input.GetAxis("DpadX");
        float DpadY = Input.GetAxis("DpadY");
        if ((DpadX != 0) || (DpadY != 0))
        {
            UnityEngine.Debug.Log("D Pad:" + DpadX + "," + DpadY);
        }


    }
}