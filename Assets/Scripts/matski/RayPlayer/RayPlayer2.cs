using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

//using static UnityEditor.PlayerSettings;

public class RayPlayer2 : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speed = 20;
    [Header("��]���x")] public float RoteSpeed = 1200.0f;
    [SerializeField] public float Speed = 8.0f;//�ړ����x

    // private Vector3 movePower = Vector3.zero;    // �L�����N�^�[�ړ��ʁi���g�p�j

    #endregion
    //�㏸����Ƃ��̃^�[�Q�b�g
    [SerializeField] private GameObject UpTarget;
    [SerializeField] private GameObject StartObject;
    [SerializeField] private bool GoalCheck=false;
    Animator animator;

    #region//�v���C�x�[�g�ϐ� 
    private Animator anim = null;
    private Rigidbody rbplayer = null;
   

    private GameObject pagemove;//pagemove���Q�Ƃ��邽�߂̕ϐ�

    private float distance_two;//�I�u�W�F�N�g�܂ł̂̋���������

    private bool AnimPlay = true;//�A�j���[�V�������Đ������ǂ����擾����

    private Vector3 target;
    [SerializeField] private GameObject movetarget;
    private Vector3 targetVector;//�^�[�Q�b�g�ւ̌���

    private Vector3 PVector;//�v���C���[�̌������i�[����
   

    private float RayYPos = -8.0f;
    [SerializeField] public bool DownCheck = false;//���������ǂ������f����flg

    private Transform objectname = null;//ray�𓖂Ă��I�u�W�F�N�g���i�[����
    private Transform nowPutobj = null;//�����̃I�u�W�F�N�g���i�[����



    public bool UpCount = false;
    public static RayPlayer2 instance;

   

    public bool PagePos;//������ꏊ���y�[�W���߂����ꏊ�����f����bool�^

    private float moveScale = 8.0f;

   
    #endregion

    //Ray�������������ǂ������f���邽�߂̕ϐ�
    private RaycastHit hit = new RaycastHit();
    private RaycastHit hitunder = new RaycastHit();

    public GameObject page;
    public GameObject[] gb;
    public bool NowMoveflg = false;//���݈ړ�����������flg
    public PlayerUp character;
    public CapsuleCollider col;
    public ChildSet Max;//MaxUp���Q�Ƃ��邽�߂̕ϐ�  
    public bool gearStop = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //�R���|�[�l���g�̃C���X�^���X��߂܂���
        //UnityEngine.Debug.Log("stick:" + LstickX + "," + LstickY);
        rbplayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        page = GameObject.Find("page");
        animator = GetComponent<Animator>();

        movetarget = StartObject;
        animator.SetBool("B_Joy", false);
        pagemove = GameObject.Find("ShaftManager");

    }

    
    void Update()
    {
        float naname = speed * 2 - speed;
        float RstickX = Input.GetAxis("RstickX");
        float LstickX = Input.GetAxis("LstickX");
        float LstickY = Input.GetAxis("LstickY");

        Vector3 RayStart;//���ۂɃ��C���΂��ʒu�̊i�[
        Vector3 RayStartUnder;

     


        //if (page.GetComponent<PageShaftVer2>().isUp == false)
        //{
        GetXSpeed();
        GetZSpeed();

       
        //Ray Ray = new Ray(transform.position, transform.forward);

        animator.SetBool("B_Idle", true);

        //�v���C���[�̍��W����y���W���������ă��C���΂�
        RayStart.x = this.transform.position.x;
        RayStart.z = this.transform.position.z;
        RayStart.y = RayYPos;

        RayStartUnder.x = this.transform.position.x;
        RayStartUnder.z = this.transform.position.z;
        RayStartUnder.y = -3.6f;

      

        //���̃I�u�W�F�N�g�̎擾
        if (Physics.Raycast(RayStartUnder, Vector3.down, out hitunder, 10.5f))
        {
            //if (hit.collider != null)
            //{
            //���ɂ���I�u�W�F�N�g���擾
            nowPutobj = hitunder.transform;
            ////���������I�u�W�F�N�g�̖��O�����O�ɏo��
            //UnityEngine.Debug.Log(hitunder.transform.name);
            //���ꂪ����Ȃ�
            if (hitunder.collider.CompareTag("Uptag_min") || hitunder.collider.CompareTag("Uptag_mid") || hitunder.collider.CompareTag("Uptag_lar")||hitunder.collider.CompareTag("Uptag_XL"))
            {
                PagePos = true;

            }
            //����ɂ���Ƃ���
            else
            {
                PagePos = false;

            }

            //}

        }

        //��ړ�����
        if (DownCheck == false)
        {
            if (NowMoveflg == false)
            {
                //�ړ����͂����������ǂ���
                if (LstickX > 0 || LstickX < 0 || LstickY > 0 || LstickY < 0)
                {
                    //�ǂ�����ǂ̌����ɔ�΂��̂��A�����������ǂ����𔻒f����
                    if (Physics.Raycast(RayStart, PVector, out hit, moveScale, LayerMask.GetMask("Default")))
                    {
                        if (hit.collider != null)
                        {
                            //Tag��Block�Qmin��������
                            if (hit.collider.CompareTag("Block_min") || hit.collider.CompareTag("Block_mid") || hit.collider.CompareTag("Uptag_min") || hit.collider.CompareTag("Uptag_mid"))
                            {
                                //�I�u�W�F�N�g��1�Ԗڂ̎q�I�u�W�F�N�g���ړ���ɂ���
                                objectname = hit.transform.GetChild(0);
                                NowMoveflg = true;
                                animator.SetBool("B_Run", true);
                                animator.GetBool("B_Run");
                            }
                            if (hit.collider.CompareTag("Block_lar") || hit.collider.CompareTag("Uptag_lar"))
                            {
                                if (hitunder.collider.CompareTag("Block_mid") || hitunder.collider.CompareTag("Uptag_mid") || hitunder.collider.CompareTag("Uptag_lar") || hitunder.collider.CompareTag("Block_lar") || hitunder.collider.CompareTag("book"))
                                {
                                    //�I�u�W�F�N�g��1�Ԗڂ̎q�I�u�W�F�N�g���ړ���ɂ���
                                    objectname = hit.transform.GetChild(0);
                                    animator.SetBool("B_Run", true);
                                    NowMoveflg = true;
                                }
                            }
                            if (hit.collider.CompareTag("block_XL") || hit.collider.CompareTag("Uptag_XL"))
                            {
                                if (hitunder.collider.CompareTag("Block_lar") || hitunder.collider.CompareTag("Uptag_lar") || hitunder.collider.CompareTag("Uptag_XL") || hitunder.collider.CompareTag("block_XL") || hitunder.collider.CompareTag("book"))
                                {
                                    //�I�u�W�F�N�g��1�Ԗڂ̎q�I�u�W�F�N�g���ړ���ɂ���
                                    objectname = hit.transform.GetChild(0);
                                    animator.SetBool("B_Run", true);
                                    NowMoveflg = true;
                                }
                            }

                            this.gameObject.transform.parent = hit.transform;
                            ////���������I�u�W�F�N�g�̖��O�����O�ɏo��
                            //UnityEngine.Debug.Log(hit.transform.name);
                        }
                    }
                }
            }
        }
        else if (DownCheck == true)
        {
            PVector = Vector3.down;
            RayYPos = -2.0f;
            //�����������ǂ����𔻒f����
            if (Physics.Raycast(RayStart, PVector, out hit, 10.0f, LayerMask.GetMask("Default")))
            {

                //Tag��Block�Qmin��������
                if (hit.collider.CompareTag("Block_min") || hit.collider.CompareTag("Nowfloat") || hit.collider.CompareTag("Block_mid") || hit.collider.CompareTag("Block_lar") || hit.collider.CompareTag("block_XL") || hit.collider.CompareTag("Uptag_min") || hit.collider.CompareTag("Uptag_mid") || hit.collider.CompareTag("Uptag_lar") || hit.collider.CompareTag("Uptag_XL"))
                {
                    //�I�u�W�F�N�g��1�Ԗڂ̎q�I�u�W�F�N�g���ړ���ɂ���
                    objectname = hit.transform.GetChild(0);
                    NowMoveflg = true;
                }
                ////���������I�u�W�F�N�g�̖��O�����O�ɏo��
                //UnityEngine.Debug.Log(hit.transform.name);

            }
        }

        if (DownCheck == true)
        {
            if ((this.transform.position.y - movetarget.transform.position.y) <= 4.1)
            {
                if (movetarget.transform.parent != null)
                {
                    if (movetarget.transform.parent.CompareTag("Block_min") || movetarget.transform.parent.CompareTag("book") || movetarget.transform.parent.CompareTag("Block_mid") || movetarget.transform.parent.CompareTag("Block_lar")|| movetarget.transform.parent.CompareTag("block_XL") || movetarget.transform.parent.CompareTag("Uptag_min") || movetarget.transform.parent.CompareTag("Uptag_mid") || movetarget.transform.parent.CompareTag("Uptag_lar") || movetarget.transform.parent.CompareTag("Uptag_XL"))
                    {
                        DownCheck = false;
                        RayYPos = -8.0f;
                        moveScale = 8.0f;
                        gearStop = false;
                        this.gameObject.transform.parent = movetarget.transform;
                    }
                }
            }
        }



        //UnityEngine.Debug.Log(this.transform.position);
        // UnityEngine.Debug.Log(movetarget.transform.position);






        //���C�̉���
        UnityEngine.Debug.DrawRay(RayStart, PVector * moveScale, Color.red);
        UnityEngine.Debug.DrawRay(RayStartUnder, Vector3.down * 10.5f, Color.blue);



        //null�̂΂����͂��̒l��Ԃ�
        if (objectname == null) return;



        //objectname���ړ���Ɏw�肷��
        movetarget = objectname.gameObject;
        //UnityEngine.Debug.Log(objectname);

        //�����y�[�W���߂����Ă�����
        //if (RstickX > 0 || RstickX < 0)

        if (Input.GetKeyDown("joystick button 0"))
        {
            if (pagemove.GetComponent<ShaftManager2>().pageMove1 == false && pagemove.GetComponent<ShaftManager2>().pageMove2 == false)
            {
                if (hitunder.collider != null)
                {
                    if (hitunder.collider.CompareTag("Uptag_min") || hitunder.collider.CompareTag("Uptag_mid") || hitunder.collider.CompareTag("Uptag_lar") || hitunder.collider.CompareTag("Uptag_XL"))
                    {
                        Debug.Log("�オ���");
                        if (UpCount == false)
                        {

                            UpCount = true;
                            //Speed = 12.0f;
                            //this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                        }

                    }
                    if (character.MaxUp == true)
                    {
                     
                        UpCount = false;
                        Speed = 8.0f;
                    }
                }

            }


        }

        if (character.MaxUp == true)
        {
            gearStop = true;
        }

            if (pagemove.GetComponent<ShaftManager2>().pageMove1 == false && pagemove.GetComponent<ShaftManager2>().pageMove2 == false)
        {
            if (character.GetComponent<PlayerUp>().MaxUp == false) // �v���C���[���ނ�グ���Ă��Ȃ��ꍇ�A�����蔻���t����
            {
                if ((LstickX != 0) || (LstickY != 0))
                {
                    col.enabled = true;
                }
            }
            // �v���C���[���ނ�グ��ꂽ��q�I�u�W�F�N�g����O��
            else
            {
                this.gameObject.transform.parent = null;
            }

        }
        // �ǂꂩ�̃y�[�W���������瓖���蔻���؂�
        else
        {
            col.enabled = false;
        }

     //        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
       if (UpCount == true)
        {
            movetarget = UpTarget;//�ړ����^��ɂ���
            DownCheck = true;
            animator.SetBool("B_Fissing", true);


            //UnityEngine.Debug.Log("�y�[�W���߂����Ă���");
        }
        else
        {

            //animator.SetBool("B_Idle", true);
        }

        if (animator.GetBool("B_Fissing") == true)
        {
            if (DownCheck == false)
            {
                animator.SetBool("B_Fissing", false);
            }
        }

        //�S�[���A�j���[�V�������I��������ǂ����̎擾
        if (animator.GetBool("B_Joy") == true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 3)
            {
                AnimPlay = true;
            }
            else
            {
                AnimPlay = false;
            }
        }  //��ʑJ��
        if (AnimPlay == false)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    private void FixedUpdate()
    {


        //�I�u�W�F�N�g���ړ���ɐݒ肷��
        targetVector = new Vector3(movetarget.transform.position.x, movetarget.transform.position.y + (movetarget.transform.localScale.y * 4), movetarget.transform.position.z);

        distance_two = Vector3.Distance(this.transform.position, targetVector);

        //�ړ�����


        float present_Location = (0.15f) / distance_two;
        if (UpCount == true || DownCheck == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetVector, 10.0f * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.Slerp(this.transform.position, targetVector, present_Location);
        }



        if (NowMoveflg == true)
        {


            if (Mathf.Abs(this.transform.position.x - movetarget.transform.position.x) <= 0.05f)
            {
                if (Mathf.Abs(this.transform.position.z - movetarget.transform.position.z) <= 0.05f)
                {
                    NowMoveflg = false;



                    if (animator.GetBool("B_RightWalk") == true)
                    {
                        animator.SetBool("B_RightWalk", false);
                    }
                   
                    present_Location = 0.0f;
                    distance_two = 0.0f;
                }
            }
        }
        else
        {

        }
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(RayStart + PVector * moveScale, 3.0f);
    //}

    /// <summary> 
    /// X���̈ړ�����
    /// </summary> 
    private float GetXSpeed()
    {
        float LstickX = Input.GetAxis("LstickX");

        if (NowMoveflg == false)
        {
            if (LstickX > 0)
            {
                PVector = Vector3.right;
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                animator.SetBool("B_RightWalk", true);
                animator.SetBool("B_FrontIdle", false);
                animator.SetBool("B_BackIdle", false);
            }
            else if (LstickX < 0)
            {

                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                animator.SetBool("B_RightWalk", true);
                animator.SetBool("B_FrontIdle", false);
                animator.SetBool("B_BackIdle", false);
                PVector = Vector3.left;


            }
            else
            {


            }
        }



        return 0.0f;
    }

    /// <summary> 
    /// Z���̈ړ�����
    /// </summary> 
    private float GetZSpeed()
    {
        float LstickY = Input.GetAxis("LstickY");
        float zSpeed = 0.0f;

        if (NowMoveflg == false)
        {
            if (LstickY < 0)
            {
                PVector = Vector3.forward;
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                animator.SetBool("B_RightWalk", true);
                animator.SetBool("B_FrontIdle", false);
                animator.SetBool("B_BackIdle", false);
            }
            else if (LstickY > 0)
            {
        
                PVector = Vector3.back;
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                animator.SetBool("B_RightWalk", true);
                animator.SetBool("B_FrontIdle", false);
                animator.SetBool("B_BackIdle", false);
            }
            else
            {

                zSpeed = 0.0f;
            }
        }
        return zSpeed;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("GoalObj"))
        {
            GoalCheck = true;
            animator.SetBool("B_Joy", true);
        }

    }
}
