using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVer2 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed = 20;
    [Header("回転速度")] public float RoteSpeed = 1200.0f;
    [Header("吊るされる速度")] public float UpSpeed = 20;

    // private Vector3 movePower = Vector3.zero;    // キャラクター移動量（未使用）

    #endregion

    #region//プライベート変数 
    private Animator anim = null;
    private Rigidbody rbplayer = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private float RunPos = 0.0f;
    private float dashTime = 0.0f;
    private float beforeKey = 0.0f;

    private float xSpeed;
    private float zSpeed;
    private float naname;
    #endregion

    public GameObject page;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        //UnityEngine.Debug.Log("stick:" + LstickX + "," + LstickY);
        rbplayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        page = GameObject.Find("pageshaft");
        xSpeed = speed;
        zSpeed = speed;

        naname = speed / 2 +(speed * 2 / (speed / 2));

    }

    void FixedUpdate()
    {
        float naname = speed * 2 - speed;

        //if (page.GetComponent<PageShaftVer2>().isUp == false)
        //{
            xSpeed = GetXSpeed();
            zSpeed = GetZSpeed();

        // Aボタン
        if (Input.GetKeyDown("joystick button 0"))
        {
            transform.localPosition = new Vector3(2, 2, 2);
        }

        if (xSpeed != 0 && zSpeed != 0)
            {
                xSpeed = GetXnanameSpeed();
                zSpeed = GetZnanameSpeed();
            }
        //}
        //else
        //{
            xSpeed = 0.0f;
            zSpeed = 0.0f;
        //}

       // UnityEngine.Debug.Log("stick:" + xSpeed + "," + zSpeed);
        //移動速度を設定
        rbplayer.velocity = new Vector3(xSpeed, -14, zSpeed);
            
            transform.localScale = new Vector3(2, 2, 2);
            isRun = true;
            dashTime += Time.deltaTime;

            // UnityEngine.Debug.Log("stick:" + LstickX + "," + LstickY);
        


    }

    /// <summary> 
    /// X軸の移動処理
    /// </summary> 
    private float GetXSpeed()
    {
        float LstickX = Input.GetAxis("LstickX");
        float xSpeed = 0.0f;

        if (LstickX > 0)
        {
            xSpeed = speed;
        }
        else if (LstickX < 0)
        {
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
        }
        return xSpeed;
    }

    /// <summary> 
    /// Z軸の移動処理
    /// </summary> 
    private float GetZSpeed()
    {
        float LstickY = Input.GetAxis("LstickY");
        float zSpeed = 0.0f;
        if (LstickY > 0)
        {
            zSpeed = speed;
        }
        else if (LstickY < 0)
        {
            zSpeed = -speed;
        }
        else
        {
            zSpeed = 0.0f;
        }
        return zSpeed;
    }

    private float GetXnanameSpeed()
    {
        float LstickX = Input.GetAxis("LstickX");
        float xSpeed = 0.0f;

        if (LstickX > 0)
        {
            xSpeed = naname;
        }
        else if (LstickX < 0)
        {
            xSpeed = -naname;
        }
        else
        {
            xSpeed = 0.0f;
        }
        return xSpeed;
    }

    /// <summary> 
    /// Z軸の移動処理
    /// </summary> 
    private float GetZnanameSpeed()
    {
        float LstickY = Input.GetAxis("LstickY");
        float zSpeed = 0.0f;
        if (LstickY > 0)
        {
            zSpeed = naname;
        }
        else if (LstickY < 0)
        {
            zSpeed = -naname;
        }
        else
        {
            zSpeed = 0.0f;
        }
        return zSpeed;
    }



    /// <summary> 
    /// アニメーションを設定する 
    /// </summary> 
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }
}