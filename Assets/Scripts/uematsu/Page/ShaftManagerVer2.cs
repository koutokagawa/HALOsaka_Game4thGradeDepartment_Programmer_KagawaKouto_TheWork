using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManagerVer2 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("１ページのpageshaftを入れる")] public GameObject Shaft1;
    [Header("１ページのpageHitを入れる")] public Pagehit PageHit1;

    [Header("２ページのpageshaftを入れる")] public GameObject Shaft2;
    [Header("２ページのpageHitを入れる")] public Pagehit PageHit2;
    #endregion

    #region//プライベート変数
    // 本の左右の一番上にあるページの値を入れる変数
    private int statebookL;
    private int statebookR;

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

    void Start()
    {
        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = false;

        // オブジェクトの位置をobjと同じ位置にする
        Shaft1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        // ページの状態を更新する
        PageState();


        // プレイヤーがどちらのページをめくるのかをLRで選択
        // 選択した方のselectpageをtrueにする。Phaseを切り替える
        if (phaseSelectLR == true)
        {
            // LBボタン
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

        // 選択した方にあるページをめくる
        if (PhasePageMove == true)
        {
            #region//ページが水平になるようにする処理
            // transformを取得
            Transform shaft1Transform = Shaft1.transform;
            Transform shaft2Transform = Shaft2.transform;
            // ローカル座標を基準に、回転を取得
            Vector3 shaft1Angle = shaft1Transform.localEulerAngles;
            Vector3 shaft2Angle = shaft2Transform.localEulerAngles;

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
                shaft1Angle.z = 180.0f;
                shaft1Transform.localEulerAngles = shaft2Angle;
            }
            if (PageHit2.GetComponent<Pagehit>().ishitR == true)
            {
                shaft2Angle.z = 0.0f;
                shaft2Transform.localEulerAngles = shaft2Angle;
            }
            #endregion

            // Lボタンが押されたときに左にあるページを動かせる
            // stateBookで本の状態を判定。pageMoveで動いているページがあるのか判定
            if (selectPageL == true)
            {
                // ページ１
                if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove2 == false)
                    {
                        Page1Shaft_ON();
                    }
                }
                // ページ２
                else if (statebookL == 2 && statebookR == 3)
                {
                    if (pageMove1 == false)
                    {
                        Page2Shaft_ON();
                      //  UnityEngine.Debug.Log("page2");
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
                    if (pageMove2 == false)
                    {
                        Page1Shaft_ON();
                    }
                }
                // ページ２
                else if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove1 == false)
                    {
                        Page2Shaft_ON();
                    }
                }
            }
        }

        // 全てのページが動いてない場合、phaseSelectをtrueにして新しくページを選択させる
        if (pageMove1 == false && pageMove2 == false)
        {
            // LとRの選択をもう一度選ぶためにどちらも切る
            selectPageL = false;
            selectPageR = false;

            phaseSelectLR = true;
            PhasePageMove = false;
        }
        else
        {
            phaseSelectLR = false;
            PhasePageMove = true;
        }
    }

    // ページの状態を取得する関数
    private void PageState()
    {
        #region//現在のページの状態を判断
        //********** ページ１が動かせる条件 ********************
        // ページ１，２が本の右にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitR == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 0;
            statebookR = 1;
        }
        // ページ１が本の左、ページ２が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** ページ２が動かせる条件 ********************
        // ページ１、２が本の左にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        // ページ１が左、ページ２が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
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
        #endregion
    }

    private void Page1Shaft_ON()
    {
        Shaft1.GetComponent<PageShaft>().enabled = true;
        Shaft2.GetComponent<PageShaft>().enabled = false;
    }

    private void Page2Shaft_ON()
    {
        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = true;
    }
}