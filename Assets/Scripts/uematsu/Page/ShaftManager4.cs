using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager4 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("１ページのpageshaftを入れる")] public GameObject Shaft1;
    [Header("１ページのpageHitを入れる")] public Pagehit PageHit1;

    [Header("２ページのpageshaftを入れる")] public GameObject Shaft2;
    [Header("２ページのpageHitを入れる")] public Pagehit PageHit2;

    [Header("３ページのpageshaftを入れる")] public GameObject Shaft3;
    [Header("３ページのpageHitを入れる")] public Pagehit PageHit3;

    [Header("４ページのpageshaftを入れる")] public GameObject Shaft4;
    [Header("４ページのpageHitを入れる")] public Pagehit PageHit4;

    [Header("１ページの光る枠を入れる")] public GameObject waku1;
    [Header("２ページの光る枠を入れる")] public GameObject waku2;
    [Header("３ページの光る枠を入れる")] public GameObject waku3;
    [Header("４ページの光る枠を入れる")] public GameObject waku4;

    [Header("characterを入れる")] public GameObject character;
    #endregion

    #region//プライベート変数
    // 本の左右の一番上にあるページの値を入れる変数
    public int statebookL;
    public int statebookR;

    // 本の状態を保存して置く変数
    private int setStateL;
    private int setStateR;

    // 本の左右どちらのページを選択しているかを判定
    // trueの場合、選択中
    private bool selectPageL = false;
    private bool selectPageR = false;

    // ページを操作する段階をboolで判定
    // trueが現在の段階
    private bool phaseSelectLR = true;
    private bool PhasePageMove = false;
    #endregion

    // それぞれのページが動いているかどうかを判定
    // trueの場合、動いている
    public bool pageMove1 = false;
    public bool pageMove2 = false;
    public bool pageMove3 = false;
    public bool pageMove4 = false;

    void Start()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);
        waku4.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft4>().enabled = false;
        Shaft2.GetComponent<PageShaft4>().enabled = false;
        Shaft3.GetComponent<PageShaft4>().enabled = false;
        Shaft4.GetComponent<PageShaft4>().enabled = false;


        // オブジェクトの位置をobjと同じ位置にする
        Shaft1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft3.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft4.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        // ページの状態が前回と違う場合
        if (setStateL == statebookL && setStateR == statebookR)
        {
            // プレイヤーがどちらのページをめくるのかをLRで選択
            // 選択した方のselectpageをtrueにする。Phaseを切り替える
            if (phaseSelectLR == true)
            {
                if (Input.GetKeyDown("joystick button 4"))
                {
                    selectPageL = true;
                    selectPageR = false;

                    phaseSelectLR = false;
                    PhasePageMove = true;
                }
                // RBボタン
                if (Input.GetKeyDown("joystick button 5"))
                {
                    selectPageL = false;
                    selectPageR = true;

                    phaseSelectLR = false;
                    PhasePageMove = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        // ページの状態を更新する
        PageState();

        if (setStateL != statebookL && setStateR != statebookR)
        {
            selectPageL = false;
            selectPageR = false;
        }
        else
        {
            // 選択した方にあるページをめくる
            if (PhasePageMove == true)
            {
                #region//ページが水平になるようにする処理
                // transformを取得
                Transform shaft1Transform = Shaft1.transform;
                Transform shaft2Transform = Shaft2.transform;
                Transform shaft3Transform = Shaft3.transform;
                Transform shaft4Transform = Shaft4.transform;
                // ローカル座標を基準に、回転を取得
                Vector3 shaft1Angle = shaft1Transform.localEulerAngles;
                Vector3 shaft2Angle = shaft2Transform.localEulerAngles;
                Vector3 shaft3Angle = shaft3Transform.localEulerAngles;
                Vector3 shaft4Angle = shaft4Transform.localEulerAngles;

                if (PageHit1.GetComponent<Pagehit>().ishitL == true)
                {
                    shaft1Angle.z = 180.0f;
                    shaft1Transform.localEulerAngles = shaft1Angle;
                }
                if (PageHit1.GetComponent<Pagehit>().ishitR == true)
                {
                    shaft1Angle.z = 0.0f;
                    shaft1Transform.localEulerAngles = shaft1Angle;
                }

                if (PageHit2.GetComponent<Pagehit>().ishitL == true)
                {
                    shaft2Angle.z = 180.0f;
                    shaft2Transform.localEulerAngles = shaft2Angle;
                }
                if (PageHit2.GetComponent<Pagehit>().ishitR == true)
                {
                    shaft2Angle.z = 0.0f;
                    shaft2Transform.localEulerAngles = shaft2Angle;
                }

                if (PageHit3.GetComponent<Pagehit>().ishitL == true)
                {
                    shaft3Angle.z = 180.0f;
                    shaft3Transform.localEulerAngles = shaft3Angle;
                }
                if (PageHit3.GetComponent<Pagehit>().ishitR == true)
                {
                    shaft3Angle.z = 0.0f;
                    shaft3Transform.localEulerAngles = shaft3Angle;
                }

                if (PageHit4.GetComponent<Pagehit>().ishitL == true)
                {
                    shaft4Angle.z = 180.0f;
                    shaft4Transform.localEulerAngles = shaft4Angle;
                }
                if (PageHit4.GetComponent<Pagehit>().ishitR == true)
                {
                    shaft4Angle.z = 0.0f;
                    shaft4Transform.localEulerAngles = shaft4Angle;
                }
                #endregion

                // Lボタンが押されたときに左にあるページを動かせる
                // stateBookで本の状態を判定。pageMoveで動いているページがあるのか判定
                if (selectPageL == true)
                {
                    // ページ１
                    if (statebookL == 1 && statebookR == 2)
                    {
                        if (pageMove2 == false && pageMove3 == false && pageMove4 == false)
                        {
                            Page1Shaft_ON();
                        }
                    }
                    // ページ２
                    else if (statebookL == 2 && statebookR == 3)
                    {
                        if (pageMove1 == false && pageMove3 == false && pageMove4 == false)
                        {
                            Page2Shaft_ON();
                        }
                    }
                    // ページ３
                    else if (statebookL == 3 && statebookR == 4)
                    {
                        if (pageMove1 == false && pageMove2 == false && pageMove4 == false)
                        {
                            Page3Shaft_ON();
                        }
                    }
                    // ページ４
                    else if (statebookL == 4 && statebookR == 5)
                    {
                        if (pageMove1 == false && pageMove2 == false && pageMove3 == false)
                        {
                            Page4Shaft_ON();
                        }
                    }
                }

                // Rボタンが押されたときに右にあるページを動かせる
                // stateBookで本の状態を判定。pageMoveで動いているページがあるのか判定
                if (selectPageR == true)
                {
                    // ページ１
                    if (statebookL == 0 && statebookR == 1)
                    {
                        if (pageMove2 == false && pageMove3 == false && pageMove4 == false)
                        {
                            Page1Shaft_ON();
                        }
                    }
                    // ページ２
                    else if (statebookL == 1 && statebookR == 2)
                    {
                        if (pageMove1 == false && pageMove3 == false && pageMove4 == false)
                        {
                            Page2Shaft_ON();
                        }
                    }
                    // ページ３
                    else if (statebookL == 2 && statebookR == 3)
                    {
                        if (pageMove1 == false && pageMove2 && pageMove4 == false)
                        {
                            Page3Shaft_ON();
                        }
                    }
                    // ページ４
                    else if (statebookL == 3 && statebookR == 4)
                    {
                        if (pageMove1 == false && pageMove2 && pageMove3 == false)
                        {
                            Page4Shaft_ON();
                        }
                    }
                }
            }
        }
    }

    // ページの状態を取得する関数
    private void PageState()
    {
        // プレイヤーが地面にいるのか判定     falseなら地面にいる
        if (character.GetComponent<RayPlayer4>().DownCheck == false)
        {
            // ページの状態を保存して置く
            setStateL = statebookL;
            setStateR = statebookR;
        }

        #region//現在のページの状態を判断
        //********** ページ１が動かせる条件 ********************
        // ページ１、２、３、４が本の右にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitR == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
             && PageHit3.GetComponent<Pagehit>().ishitR == true
             && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 0;
            statebookR = 1;
        }
        // ページ１が本の左、ページ２、３、４が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitR == true
             && PageHit3.GetComponent<Pagehit>().ishitR == true
             && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** ページ２が動かせる条件 ********************
        // ページ１、２が本の左、３、４が右にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true
            && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        // ページ１が左、ページ２、３、４が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true
            && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** ページ３が動かせる条件 ********************
        // ページ１、２、３が本の左、４が右にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitL == true
             && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 3;
            statebookR = 4;
        }
        // ページ１、２が左、３、４が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true
            && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }

        //********** ページ４が動かせる条件 ********************
        // ページ１、２、３、４が本の左にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitL == true
             && PageHit4.GetComponent<Pagehit>().ishitL == true)
        {
            statebookL = 4;
            statebookR = 5;
        }
        // ページ１、２、３が左４が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitL == true
            && PageHit4.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 3;
            statebookR = 4;
        }
        #endregion

        #region//現在めくられているページ取得
        // 現在めくられているページを判定する
        // めくられているページがある場合は phaseSelectLRに入れないようにする
        if (PageHit1.GetComponent<Pagehit>().ishitL == false && PageHit1.GetComponent<Pagehit>().ishitR == false)
        {
            phaseSelectLR = false;
            pageMove1 = true;
        }
        if (PageHit2.GetComponent<Pagehit>().ishitL == false && PageHit2.GetComponent<Pagehit>().ishitR == false)
        {
            phaseSelectLR = false;
            pageMove2 = true;
        }
        if (PageHit3.GetComponent<Pagehit>().ishitL == false && PageHit3.GetComponent<Pagehit>().ishitR == false)
        {
            phaseSelectLR = false;
            pageMove3 = true;
        }

        // ページが本の左右どちらかに当たっているのか
        if (PageHit1.GetComponent<Pagehit>().ishitL == true && PageHit1.GetComponent<Pagehit>().ishitR == false
            || PageHit1.GetComponent<Pagehit>().ishitL == false && PageHit1.GetComponent<Pagehit>().ishitR == true)
        {
            phaseSelectLR = true;
            pageMove1 = false;
        }
        if (PageHit2.GetComponent<Pagehit>().ishitL == true && PageHit2.GetComponent<Pagehit>().ishitR == false
            || PageHit2.GetComponent<Pagehit>().ishitL == false && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            phaseSelectLR = true;
            pageMove2 = false;
        }
        if (PageHit3.GetComponent<Pagehit>().ishitL == true && PageHit3.GetComponent<Pagehit>().ishitR == false
            || PageHit3.GetComponent<Pagehit>().ishitL == false && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            phaseSelectLR = true;
            pageMove3 = false;
        }
        #endregion
    }

    private void Page1Shaft_ON()
    {
        waku1.gameObject.SetActive(true);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft>().enabled = true;
        Shaft2.GetComponent<PageShaft>().enabled = false;
        Shaft3.GetComponent<PageShaft>().enabled = false;
    }

    private void Page2Shaft_ON()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(true);
        waku3.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = true;
        Shaft3.GetComponent<PageShaft>().enabled = false;

    }

    private void Page3Shaft_ON()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(true);

        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = false;
        Shaft3.GetComponent<PageShaft>().enabled = true;
    }

    private void Page4Shaft_ON()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);
        waku4.gameObject.SetActive(true);

        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = false;
        Shaft3.GetComponent<PageShaft>().enabled = false;
        Shaft4.GetComponent<PageShaft>().enabled = true;
    }

    private void ShahtAllOFF()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);
        waku4.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = false;
        Shaft3.GetComponent<PageShaft>().enabled = false;
        Shaft4.GetComponent<PageShaft>().enabled = false;
    }
}