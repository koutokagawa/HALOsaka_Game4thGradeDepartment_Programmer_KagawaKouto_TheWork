using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MainShaft : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�P�y�[�W��pageshaft������")] public PageShaft PageRotation1;
    [Header("�P�y�[�W��pageHit������")] public Pagehit PageHit1;
    [Header("�Q�y�[�W��pageshaft������")] public PageShaft PageRotation2;
    [Header("�Q�y�[�W��pageHit������")] public Pagehit PageHit2;
    [Header("�R�y�[�W��pageshaft������")] public PageShaft PageRotation3;
    [Header("�R�y�[�W��pageHit������")] public Pagehit PageHit3;
    #endregion

    #region//�v���C�x�[�g�ϐ�
    // �����ɂ߂����y�[�W���Ȃ��ꍇ�O
    // �E���ɂ߂����y�[�W���Ȃ��ꍇ�O�@�i�{�̃y�[�W���ɍ��킹�ĕω��j
    private int startHitPageL = 0;
    private int startHitPageR = 4;

    // �{�̍��E�̈�ԏ�ɂ���y�[�W�̒l������ϐ�
    private int statebookL;
    private int statebookR;

    // �{�̍��E�ǂ���̃y�[�W��I�����Ă��邩�𔻒�
    // true�̏ꍇ�A�I��
    private bool selectPageL = false;
    private bool selectPageR = false;

    // �y�[�W�𑀍삷��i�K��bool�Ŕ���
    // true�����݂̒i�K
    private bool phaseSelectLR = true;
    private bool PhasePageMove = false;

    // ���ꂼ��̃y�[�W�������Ă��邩�ǂ����𔻒�
    // true�̏ꍇ�A�����Ă���
    private bool pageMove1 = false;
    private bool pageMove2 = false;
    private bool pageMove3 = false;
    #endregion

    void Start()
    {
        // �S�Ẵy�[�W��PageShaft��؂�
        PageRotation1.GetComponent<PageShaft>().enabled = false;
        PageRotation2.GetComponent<PageShaft>().enabled = false;
        PageRotation3.GetComponent<PageShaft>().enabled = false;
    }

    void Update()
    {
        // �y�[�W�̏�Ԃ��X�V����
        PageState();

        // �v���C���[���ǂ���̃y�[�W���߂���̂��I��
        // �I����������selectpage��true�ɂ���BPhase��؂�ւ���B
        if (phaseSelectLR == true)
        {
            // �y�[�W�̂ǂ��炩���I������Ă���ꍇ
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

            // LB�{�^��
            if (Input.GetKeyDown("joystick button 4"))
            {
                selectPageL = true;
                selectPageR = false;

                phaseSelectLR = false;
                PhasePageMove = true;
            }
            // RB�{�^��
            if (Input.GetKeyDown("joystick button 5"))
            {
                selectPageL = false;
                selectPageR = true;

                phaseSelectLR = false;
                PhasePageMove = true;
            }
        }

        // �I���������ɂ���y�[�W���߂���
        if (PhasePageMove == true)
        {
            // L�{�^���������ꂽ�Ƃ��ɍ��ɂ���y�[�W�𓮂�����
            // stateBook�Ŗ{�̏�Ԃ𔻒�BpageMove�œ����Ă���y�[�W������̂�����
            if (selectPageL == true)
            {
                // �y�[�W�P
                if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove2 == false && pageMove3 == false)
                    {
                        Page1ON();
                    }
                }
                // �y�[�W�Q
                else if (statebookL == 2 && statebookR == 3)
                {
                    if (pageMove1 == false && pageMove3 == false)
                    {
                        Page2ON();
                    }
                }
                // �y�[�W�R
                else if (statebookL == 3 && statebookR == 4)
                {
                    if (pageMove1 == false && pageMove2 == false)
                    {
                        Page3ON();
                    }
                }
            }

            // R�{�^���������ꂽ�Ƃ��ɉE�ɂ���y�[�W�𓮂�����
            // stateBook�Ŗ{�̏�Ԃ𔻒�BpageMove�œ����Ă���y�[�W������̂�����
            if (selectPageR == true)
            {
                // �y�[�W�P
                if (statebookL == 0 && statebookR == 1)
                {
                    if (pageMove2 == false && pageMove3 == false)
                    {
                        Page1ON();
                    }
                }
                // �y�[�W�Q
                else if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove1 == false && pageMove3 == false)
                    {
                        Page2ON();
                    }
                }
                // �y�[�W�R
                else if (statebookL == 2 && statebookR == 3)
                {
                    if (pageMove1 == false && pageMove2 == false)
                    {
                        Page3ON();
                    }
                }
            }
        }

        // �S�Ẵy�[�W�������ĂȂ��ꍇ
        if (pageMove1 == false && pageMove2 == false && pageMove3 == false)
        {
            

        }

    }

    // �y�[�W�̏�Ԃ��擾����֐�
    private void PageState()
    {
        #region//���݂̃y�[�W�̏�Ԃ𔻒f
        //********** �y�[�W�P������������� ********************
        // �y�[�W�P�C�Q�A�R���{�̉E�ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitR == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 0;
            statebookR = 1;
        }
        // �y�[�W�P���{�̍��A�y�[�W�Q�A�R���{�̉E�ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitR == true
             && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** �y�[�W�Q������������� ********************
        // �y�[�W�P�A�Q���{�̍��A�y�[�W�R���{�̉E�ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        // �y�[�W�Q�A�R���{�̉E�A�y�[�W�P���{�̍��ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }


        //********** �y�[�W�R������������� ********************
        // �y�[�W�P�C�Q�A�R���{�̍��ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitL == true)
        {
            statebookL = 3;
            statebookR = 4;
        }
        // �y�[�W�R���{�̉E�A�y�[�W�P�A�Q���{�̍��ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitL == true
             && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        #endregion

        #region//���݂߂����Ă���y�[�W�擾
        // ���݂߂����Ă���y�[�W�𔻒肷��
        // �߂����Ă���y�[�W������ꍇ�� phaseLRselect�ɓ���Ȃ��悤�ɂ���
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

        // �y�[�W���{�̍��E�ǂ��炩�ɓ������Ă���̂�
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