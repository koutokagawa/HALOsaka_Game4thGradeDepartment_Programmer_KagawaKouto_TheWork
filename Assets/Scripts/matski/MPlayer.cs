using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MPlayer : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    #endregion

    #region//プライベート変数 
    private Animator anim = null;
    private Rigidbody2D rbplayer = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private float RunPos = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;

    private float xSpeed;
    private float zSpeed;
    private float naname;

    private int moveNo = 0;
    private bool moveflgx = false;
    private bool moveflgz = false;

    private int Downsave = 0;
    private float DownPos = 0.0f;
    private bool Downflg = false;


    #endregion

    public GameObject page;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rbplayer = GetComponent<Rigidbody2D>();
        page = GameObject.Find("pageshaft");
        xSpeed = speed;
        zSpeed = speed;

        naname = speed / 2 + (speed * 2 / (speed / 2));
    }

    void FixedUpdate()
    {
        float naname = speed * 2 - speed;


        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //各種座標軸の速度を求める
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();
        float zspeed = GetZSpeed();

        //アニメーションを適用
        SetAnimation();

        //移動速度を設定
        rbplayer.velocity = new Vector2(xSpeed, ySpeed);
    }

    /// <summary> 
    /// Z軸の移動処理
    /// </summary> 
    private float GetZSpeed()
    {
        float LstickY = Input.GetAxis("LstickY");
   
        Transform myTransForm = this.transform;
        Vector3 Pos = myTransForm.position;
        if (LstickY > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
        
            if (moveflgz == false)
            {
                this.transform.position = new Vector3(Pos.x, Pos.y, Pos.z+1.0f);
                moveflgz = true;
            }
        }
        else if (LstickY < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            if (moveflgz == false)
            {
                this.transform.position = new Vector3(Pos.x, Pos.y, Pos.z - 1.0f);
                moveflgz = true;
            }
        }
        else
        {
            zSpeed = 0.0f;
            moveflgz = false;
        }
        return zSpeed;
    }


    /// <summary> 
    /// Y成分で必要な計算をし、速度を返す。 
    /// </summary> 
    /// <returns>Y軸の速さ</returns> 
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        Transform myTransForm = this.transform;
        Vector3 Pos = myTransForm.position;

        if (page.GetComponent<MPageShaft>().isUp == false)
        {

            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }

            if (isJump)
            {
                //上方向キーを押しているか
                bool pushUpKey = verticalKey > 0;
                //現在の高さが飛べる高さより下か
                bool canHeight = jumpPos + jumpHeight > transform.position.y;
                //ジャンプ時間が長くなりすぎてないか
                bool canTime = jumpLimitTime > jumpTime;

                if (pushUpKey && canHeight && canTime && !isHead)
                {
                    ySpeed = jumpSpeed;
                    jumpTime += Time.deltaTime;
                }
                else
                {
                    isJump = false;
                    jumpTime = 0.0f;
                }
            }

            if (isJump)
            {
                ySpeed *= jumpCurve.Evaluate(jumpTime);
            }
        }
        if (page.GetComponent<MPageShaft>().isUp == true)
        {
            if (Downsave == 0)
            {
                DownPos = transform.position.y; //ジャンプした位置を記録する
            }
            ySpeed = jumpSpeed * 8;
            Downflg = true;
        }
        if (page.GetComponent<MPageShaft>().isUp == false && Downflg == true)
        {
            ySpeed = -jumpSpeed * 8;
            if (Pos.y == Downsave)
            {
                Downflg = false;
            }
        }
        return ySpeed;
    }

    /// <summary> 
    /// X成分で必要な計算をし、速度を返す。 
    /// </summary> 
    /// <returns>X軸の速さ</returns> 
    private float GetXSpeed()
    {
        float LstickX = Input.GetAxis("LstickX");
        float xSpeed = 0.0f;
        Transform myTransForm = this.transform;
        Vector3 Pos = myTransForm.position;

        if (page.GetComponent<MPageShaft>().isUp == false)
        {
            if (LstickX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isRun = true;
                dashTime += Time.deltaTime;

                moveNo++;
                if (moveflgx == false)
                {
                    this.transform.position = new Vector3(Pos.x+1.0f, Pos.y, Pos.z);
                    moveflgx = true;
                }


            }
            else if (LstickX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isRun = true;
                dashTime += Time.deltaTime;

                moveNo--;
                if (moveflgx == false)
                {
                    this.transform.position = new Vector3(Pos.x-1.0f, Pos.y, Pos.z);
                    moveflgx = true;
                }


            }
            else
            {
                isRun = false;
                xSpeed = 0.0f;
                dashTime = 0.0f;
                moveflgx = false;
            }

            //前回の入力からダッシュの反転を判断して速度を変える
            if (LstickX > 0 && LstickX < 0)
            {
                dashTime = 0.0f;
            }
            else if (LstickX < 0 && LstickX > 0)
            {
                dashTime = 0.0f;
            }

            RunPos = transform.position.x; //キャラクター位置を記録する


        }


        return xSpeed;
    }

    /// <summary> 
    /// アニメーションを設定する 
    /// </summary> 
    /// 

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
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }
}