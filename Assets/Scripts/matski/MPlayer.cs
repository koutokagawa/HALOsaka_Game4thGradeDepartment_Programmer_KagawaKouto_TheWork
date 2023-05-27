using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MPlayer : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speed;
    [Header("�d��")] public float gravity;
    [Header("�W�����v���x")] public float jumpSpeed;
    [Header("�W�����v���鍂��")] public float jumpHeight;
    [Header("�W�����v���钷��")] public float jumpLimitTime;
    [Header("�ڒn����")] public GroundCheck ground;
    [Header("�V�䔻��")] public GroundCheck head;
    [Header("�_�b�V���̑����\��")] public AnimationCurve dashCurve;
    [Header("�W�����v�̑����\��")] public AnimationCurve jumpCurve;
    #endregion

    #region//�v���C�x�[�g�ϐ� 
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
        //�R���|�[�l���g�̃C���X�^���X��߂܂���
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


        //�ڒn����𓾂�
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //�e����W���̑��x�����߂�
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();
        float zspeed = GetZSpeed();

        //�A�j���[�V������K�p
        SetAnimation();

        //�ړ����x��ݒ�
        rbplayer.velocity = new Vector2(xSpeed, ySpeed);
    }

    /// <summary> 
    /// Z���̈ړ�����
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
    /// Y�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B 
    /// </summary> 
    /// <returns>Y���̑���</returns> 
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
                jumpPos = transform.position.y; //�W�����v�����ʒu���L�^����
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }

            if (isJump)
            {
                //������L�[�������Ă��邩
                bool pushUpKey = verticalKey > 0;
                //���݂̍�������ׂ鍂����艺��
                bool canHeight = jumpPos + jumpHeight > transform.position.y;
                //�W�����v���Ԃ������Ȃ肷���ĂȂ���
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
                DownPos = transform.position.y; //�W�����v�����ʒu���L�^����
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
    /// X�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B 
    /// </summary> 
    /// <returns>X���̑���</returns> 
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

            //�O��̓��͂���_�b�V���̔��]�𔻒f���đ��x��ς���
            if (LstickX > 0 && LstickX < 0)
            {
                dashTime = 0.0f;
            }
            else if (LstickX < 0 && LstickX > 0)
            {
                dashTime = 0.0f;
            }

            RunPos = transform.position.x; //�L�����N�^�[�ʒu���L�^����


        }


        return xSpeed;
    }

    /// <summary> 
    /// �A�j���[�V������ݒ肷�� 
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
    /// Z���̈ړ�����
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