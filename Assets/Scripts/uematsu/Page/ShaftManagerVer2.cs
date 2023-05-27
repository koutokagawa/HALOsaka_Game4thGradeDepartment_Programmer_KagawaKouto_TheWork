using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManagerVer2 : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�P�y�[�W��pageshaft������")] public GameObject Shaft1;
    [Header("�P�y�[�W��pageHit������")] public Pagehit PageHit1;

    [Header("�Q�y�[�W��pageshaft������")] public GameObject Shaft2;
    [Header("�Q�y�[�W��pageHit������")] public Pagehit PageHit2;
    #endregion

    #region//�v���C�x�[�g�ϐ�
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
    #endregion

    // ���ꂼ��̃y�[�W�������Ă��邩�ǂ����𔻒�
    // true�̏ꍇ�A�����Ă���
    public bool pageMove1 = false;
    public bool pageMove2 = false;

    void Start()
    {
        Shaft1.GetComponent<PageShaft>().enabled = false;
        Shaft2.GetComponent<PageShaft>().enabled = false;

        // �I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
        Shaft1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        // �y�[�W�̏�Ԃ��X�V����
        PageState();


        // �v���C���[���ǂ���̃y�[�W���߂���̂���LR�őI��
        // �I����������selectpage��true�ɂ���BPhase��؂�ւ���
        if (phaseSelectLR == true)
        {
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
            #region//�y�[�W�������ɂȂ�悤�ɂ��鏈��
            // transform���擾
            Transform shaft1Transform = Shaft1.transform;
            Transform shaft2Transform = Shaft2.transform;
            // ���[�J�����W����ɁA��]���擾
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

            // L�{�^���������ꂽ�Ƃ��ɍ��ɂ���y�[�W�𓮂�����
            // stateBook�Ŗ{�̏�Ԃ𔻒�BpageMove�œ����Ă���y�[�W������̂�����
            if (selectPageL == true)
            {
                // �y�[�W�P
                if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove2 == false)
                    {
                        Page1Shaft_ON();
                    }
                }
                // �y�[�W�Q
                else if (statebookL == 2 && statebookR == 3)
                {
                    if (pageMove1 == false)
                    {
                        Page2Shaft_ON();
                      //  UnityEngine.Debug.Log("page2");
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
                    if (pageMove2 == false)
                    {
                        Page1Shaft_ON();
                    }
                }
                // �y�[�W�Q
                else if (statebookL == 1 && statebookR == 2)
                {
                    if (pageMove1 == false)
                    {
                        Page2Shaft_ON();
                    }
                }
            }
        }

        // �S�Ẵy�[�W�������ĂȂ��ꍇ�AphaseSelect��true�ɂ��ĐV�����y�[�W��I��������
        if (pageMove1 == false && pageMove2 == false)
        {
            // L��R�̑I����������x�I�Ԃ��߂ɂǂ�����؂�
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

    // �y�[�W�̏�Ԃ��擾����֐�
    private void PageState()
    {
        #region//���݂̃y�[�W�̏�Ԃ𔻒f
        //********** �y�[�W�P������������� ********************
        // �y�[�W�P�C�Q���{�̉E�ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitR == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 0;
            statebookR = 1;
        }
        // �y�[�W�P���{�̍��A�y�[�W�Q���{�̉E�ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
             && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** �y�[�W�Q������������� ********************
        // �y�[�W�P�A�Q���{�̍��ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        // �y�[�W�P�����A�y�[�W�Q���{�̉E�ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }
        #endregion

        #region//���݂߂����Ă���y�[�W�擾
        // ���݂߂����Ă���y�[�W�𔻒肷��
        // �߂����Ă���y�[�W������ꍇ�� phaseSelectLR�ɓ���Ȃ��悤�ɂ���
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