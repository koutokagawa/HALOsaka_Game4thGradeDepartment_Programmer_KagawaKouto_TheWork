using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MainShaft : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("１ページのpageshaftを入れる")] public PageShaft PageRotation1;
    [Header("１ページのpageHitを入れる")] public Pagehit PageHit1;
    [Header("２ページのpageshaftを入れる")] public PageShaft PageRotation2;
    [Header("２ページのpageHitを入れる")] public Pagehit PageHit2;
    [Header("３ページのpageshaftを入れる")] public PageShaft PageRotation3;
    [Header("３ページのpageHitを入れる")] public Pagehit PageHit3;
    #endregion

    #region//プライベート変数
    // 左側にめくれるページがない場合０
    // 右側にめくれるページがない場合０　（本のページ数に合わせて変化）
    private int startHitPageL = 0;
    private int startHitPageR = 4;

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

    // それぞれのページが動いているかどうかを判定
    // trueの場合、動いている
    private bool pageMove1 = false;
    private bool pageMove2 = false;
    private bool pageMove3 = false;
    #endregion

    void Start()
    {
        // 全てのページのPageShaftを切る
        PageRotation1.GetComponent<PageShaft>().enabled = false;
        PageRotation2.GetComponent<PageShaft>().enabled = false;
        PageRotation3.GetComponent<PageShaft>().enabled = false;
    }

    void Update()
    {
        // ページの状態を更新する
        PageState();

        // プレイヤーがどちらのページをめくるのか選択
        // 選択した方のselectpageをtrueにする。Phaseを切り替える。
        if (phaseSelectLR == true)
        {
            // ページのどちらかが選択されている場合
            if (selectPageL == true || selectPageR == true)
            {
                phaseSelectLR = false;
                PhasePageMove = true;

                selectPageL = false;
                selectPageR = false;
                UnityEngine.Debug.Log("A");
            }
            else
            {
                
                phaseSelectLR = true;
                PhasePageMove = false;
            }

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
            // Lボタンが押されたときに左にあるページを動かせる
            // stateBookで本の状態を判定。pageMoveで動いているページがあるのか判定
            if (selectPageL == true)
            {
                // ページ１
                if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove2 == false && pageMove3 == false)
                    {
                        Page1ON();
                    }
                }
                // ページ２
                else if (statebookL == 2 && statebookR == 3)
                {
                    if (pageMove1 == false && pageMove3 == false)
                    {
                        Page2ON();
                    }
                }
                // ページ３
                else if (statebookL == 3 && statebookR == 4)
                {
                    if (pageMove1 == false && pageMove2 == false)
                    {
                        Page3ON();
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
                    if (pageMove2 == false && pageMove3 == false)
                    {
                        Page1ON();
                    }
                }
                // ページ２
                else if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove1 == false && pageMove3 == false)
                    {
                        Page2ON();
                    }
                }
                // ページ３
                else if (statebookL == 2 && statebookR == 3)
                {
                    if (pageMove1 == false && pageMove2 == false)
                    {
                        Page3ON();
                    }
                }
            }
        }

        // 全てのページが動いてない場合
        if (pageMove1 == false && pageMove2 == false && pageMove3 == false)
        {
            

        }

    }

    // ページの状態を取得する関数
    private void PageState()
    {
        #region//現在のページの状態を判断
        //********** ページ１が動かせる条件 ********************
        // ページ１，２、３が本の右にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitR == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 0;
            statebookR = 1;
        }
        // ページ１が本の左、ページ２、３が本の右にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitR == true
             && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** ページ２が動かせる条件 ********************
        // ページ１、２が本の左、ページ３が本の右にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        // ページ２、３が本の右、ページ１が本の左にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }


        //********** ページ３が動かせる条件 ********************
        // ページ１，２、３が本の左にある場合
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitL == true)
        {
            statebookL = 3;
            statebookR = 4;
        }
        // ページ３が本の右、ページ１、２が本の左にある場合
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitL == true
             && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        #endregion

        #region//現在めくられているページ取得
        // 現在めくられているページを判定する
        // めくられているページがある場合は phaseLRselectに入れないようにする
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

    private void Page1ON()
    {
        PageRotation1.GetComponent<PageShaft>().enabled = true;
        PageRotation2.GetComponent<PageShaft>().enabled = false;
        PageRotation3.GetComponent<PageShaft>().enabled = false;
    }

    private void Page2ON()
    {
        PageRotation1.GetComponent<PageShaft>().enabled = false;
        PageRotation2.GetComponent<PageShaft>().enabled = true;
        PageRotation3.GetComponent<PageShaft>().enabled = false;
    }

    private void Page3ON()
    {
        PageRotation1.GetComponent<PageShaft>().enabled = false;
        PageRotation2.GetComponent<PageShaft>().enabled = false;
        PageRotation3.GetComponent<PageShaft>().enabled = true;
    }
}