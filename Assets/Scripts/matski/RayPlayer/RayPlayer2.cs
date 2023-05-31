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
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed = 20;
    [Header("回転速度")] public float RoteSpeed = 1200.0f;
    [SerializeField] public float Speed = 8.0f;//移動速度

    // private Vector3 movePower = Vector3.zero;    // キャラクター移動量（未使用）

    #endregion
    //上昇するときのターゲット
    [SerializeField] private GameObject UpTarget;
    [SerializeField] private GameObject StartObject;
    [SerializeField] private bool GoalCheck=false;
    Animator animator;

    #region//プライベート変数 
    private Animator anim = null;
    private Rigidbody rbplayer = null;
   

    private GameObject pagemove;//pagemoveを参照するための変数

    private float distance_two;//オブジェクトまでのの距離を入れる

    private bool AnimPlay = true;//アニメーションが再生中かどうか取得する

    private Vector3 target;
    [SerializeField] private GameObject movetarget;
    private Vector3 targetVector;//ターゲットへの向き

    private Vector3 PVector;//プレイヤーの向きを格納する
   

    private float RayYPos = -8.0f;
    [SerializeField] public bool DownCheck = false;//落下中かどうか判断するflg

    private Transform objectname = null;//rayを当てたオブジェクトを格納する
    private Transform nowPutobj = null;//足元のオブジェクトを格納する



    public bool UpCount = false;
    public static RayPlayer2 instance;

   

    public bool PagePos;//今いる場所がページをめくれる場所か判断するbool型

    private float moveScale = 8.0f;

   
    #endregion

    //Rayが当たったかどうか判断するための変数
    private RaycastHit hit = new RaycastHit();
    private RaycastHit hitunder = new RaycastHit();

    public GameObject page;
    public GameObject[] gb;
    public bool NowMoveflg = false;//現在移動中かを示すflg
    public PlayerUp character;
    public CapsuleCollider col;
    public ChildSet Max;//MaxUpを参照するための変数  
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
        //コンポーネントのインスタンスを捕まえる
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

        Vector3 RayStart;//実際にレイを飛ばす位置の格納
        Vector3 RayStartUnder;

     


        //if (page.GetComponent<PageShaftVer2>().isUp == false)
        //{
        GetXSpeed();
        GetZSpeed();

       
        //Ray Ray = new Ray(transform.position, transform.forward);

        animator.SetBool("B_Idle", true);

        //プレイヤーの座標からy座標だけ下げてレイを飛ばす
        RayStart.x = this.transform.position.x;
        RayStart.z = this.transform.position.z;
        RayStart.y = RayYPos;

        RayStartUnder.x = this.transform.position.x;
        RayStartUnder.z = this.transform.position.z;
        RayStartUnder.y = -3.6f;

      

        //下のオブジェクトの取得
        if (Physics.Raycast(RayStartUnder, Vector3.down, out hitunder, 10.5f))
        {
            //if (hit.collider != null)
            //{
            //下にあるオブジェクトを取得
            nowPutobj = hitunder.transform;
            ////当たったオブジェクトの名前をログに出す
            //UnityEngine.Debug.Log(hitunder.transform.name);
            //それが足場なら
            if (hitunder.collider.CompareTag("Uptag_min") || hitunder.collider.CompareTag("Uptag_mid") || hitunder.collider.CompareTag("Uptag_lar")||hitunder.collider.CompareTag("Uptag_XL"))
            {
                PagePos = true;

            }
            //足場にいるときに
            else
            {
                PagePos = false;

            }

            //}

        }

        //非移動時に
        if (DownCheck == false)
        {
            if (NowMoveflg == false)
            {
                //移動入力があったかどうか
                if (LstickX > 0 || LstickX < 0 || LstickY > 0 || LstickY < 0)
                {
                    //どこからどの向きに飛ばすのか、当たったかどうかを判断する
                    if (Physics.Raycast(RayStart, PVector, out hit, moveScale, LayerMask.GetMask("Default")))
                    {
                        if (hit.collider != null)
                        {
                            //TagがBlock＿minだったら
                            if (hit.collider.CompareTag("Block_min") || hit.collider.CompareTag("Block_mid") || hit.collider.CompareTag("Uptag_min") || hit.collider.CompareTag("Uptag_mid"))
                            {
                                //オブジェクトの1番目の子オブジェクトを移動先にする
                                objectname = hit.transform.GetChild(0);
                                NowMoveflg = true;
                                animator.SetBool("B_Run", true);
                                animator.GetBool("B_Run");
                            }
                            if (hit.collider.CompareTag("Block_lar") || hit.collider.CompareTag("Uptag_lar"))
                            {
                                if (hitunder.collider.CompareTag("Block_mid") || hitunder.collider.CompareTag("Uptag_mid") || hitunder.collider.CompareTag("Uptag_lar") || hitunder.collider.CompareTag("Block_lar") || hitunder.collider.CompareTag("book"))
                                {
                                    //オブジェクトの1番目の子オブジェクトを移動先にする
                                    objectname = hit.transform.GetChild(0);
                                    animator.SetBool("B_Run", true);
                                    NowMoveflg = true;
                                }
                            }
                            if (hit.collider.CompareTag("block_XL") || hit.collider.CompareTag("Uptag_XL"))
                            {
                                if (hitunder.collider.CompareTag("Block_lar") || hitunder.collider.CompareTag("Uptag_lar") || hitunder.collider.CompareTag("Uptag_XL") || hitunder.collider.CompareTag("block_XL") || hitunder.collider.CompareTag("book"))
                                {
                                    //オブジェクトの1番目の子オブジェクトを移動先にする
                                    objectname = hit.transform.GetChild(0);
                                    animator.SetBool("B_Run", true);
                                    NowMoveflg = true;
                                }
                            }

                            this.gameObject.transform.parent = hit.transform;
                            ////当たったオブジェクトの名前をログに出す
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
            //当たったかどうかを判断する
            if (Physics.Raycast(RayStart, PVector, out hit, 10.0f, LayerMask.GetMask("Default")))
            {

                //TagがBlock＿minだったら
                if (hit.collider.CompareTag("Block_min") || hit.collider.CompareTag("Nowfloat") || hit.collider.CompareTag("Block_mid") || hit.collider.CompareTag("Block_lar") || hit.collider.CompareTag("block_XL") || hit.collider.CompareTag("Uptag_min") || hit.collider.CompareTag("Uptag_mid") || hit.collider.CompareTag("Uptag_lar") || hit.collider.CompareTag("Uptag_XL"))
                {
                    //オブジェクトの1番目の子オブジェクトを移動先にする
                    objectname = hit.transform.GetChild(0);
                    NowMoveflg = true;
                }
                ////当たったオブジェクトの名前をログに出す
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






        //レイの可視化
        UnityEngine.Debug.DrawRay(RayStart, PVector * moveScale, Color.red);
        UnityEngine.Debug.DrawRay(RayStartUnder, Vector3.down * 10.5f, Color.blue);



        //nullのばあいはその値を返す
        if (objectname == null) return;



        //objectnameを移動先に指定する
        movetarget = objectname.gameObject;
        //UnityEngine.Debug.Log(objectname);

        //もしページがめくられていたら
        //if (RstickX > 0 || RstickX < 0)

        if (Input.GetKeyDown("joystick button 0"))
        {
            if (pagemove.GetComponent<ShaftManager2>().pageMove1 == false && pagemove.GetComponent<ShaftManager2>().pageMove2 == false)
            {
                if (hitunder.collider != null)
                {
                    if (hitunder.collider.CompareTag("Uptag_min") || hitunder.collider.CompareTag("Uptag_mid") || hitunder.collider.CompareTag("Uptag_lar") || hitunder.collider.CompareTag("Uptag_XL"))
                    {
                        Debug.Log("上がれる");
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
            if (character.GetComponent<PlayerUp>().MaxUp == false) // プレイヤーが釣り上げられていない場合、当たり判定を付ける
            {
                if ((LstickX != 0) || (LstickY != 0))
                {
                    col.enabled = true;
                }
            }
            // プレイヤーが釣り上げられたら子オブジェクトから外す
            else
            {
                this.gameObject.transform.parent = null;
            }

        }
        // どれかのページが動いたら当たり判定を切る
        else
        {
            col.enabled = false;
        }

     //        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
       if (UpCount == true)
        {
            movetarget = UpTarget;//移動先を真上にする
            DownCheck = true;
            animator.SetBool("B_Fissing", true);


            //UnityEngine.Debug.Log("ページをめくっている");
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

        //ゴールアニメーションが終わったかどうかの取得
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
        }  //画面遷移
        if (AnimPlay == false)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    private void FixedUpdate()
    {


        //オブジェクトを移動先に設定する
        targetVector = new Vector3(movetarget.transform.position.x, movetarget.transform.position.y + (movetarget.transform.localScale.y * 4), movetarget.transform.position.z);

        distance_two = Vector3.Distance(this.transform.position, targetVector);

        //移動処理


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
    /// X軸の移動処理
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
    /// Z軸の移動処理
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
