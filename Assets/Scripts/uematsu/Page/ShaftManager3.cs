using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager3 : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�P�y�[�W��pageshaft������")] public GameObject Shaft1;
    [Header("�P�y�[�W��pageHit������")] public Pagehit PageHit1;

    [Header("�Q�y�[�W��pageshaft������")] public GameObject Shaft2;
    [Header("�Q�y�[�W��pageHit������")] public Pagehit PageHit2;

    [Header("�R�y�[�W��pageshaft������")] public GameObject Shaft3;
    [Header("�R�y�[�W��pageHit������")] public Pagehit PageHit3;


    [Header("�P�y�[�W�̌���g������")] public GameObject waku1;
    [Header("�Q�y�[�W�̌���g������")] public GameObject waku2;
    [Header("�R�y�[�W�̌���g������")] public GameObject waku3;

    [Header("character������")] public GameObject character;
    #endregion

    #region//�v���C�x�[�g�ϐ�
    // �{�̍��E�̈�ԏ�ɂ���y�[�W�̒l������ϐ�
    public int statebookL;
    public int statebookR;

    // �{�̏�Ԃ�ۑ����Ēu���ϐ�
    private int setStateL;
    private int setStateR;

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
    public bool pageMove3 = false;

    void Start()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft3>().enabled = false;
        Shaft2.GetComponent<PageShaft3>().enabled = false;
        Shaft3.GetComponent<PageShaft3>().enabled = false;

        // �I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
        Shaft1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Shaft3.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        // �y�[�W�̏�Ԃ��O��ƈႤ�ꍇ
        if (setStateL == statebookL && setStateR == statebookR)
        {
            // �v���C���[���ǂ���̃y�[�W���߂���̂���LR�őI��
            // �I����������selectpage��true�ɂ���BPhase��؂�ւ���
            if (phaseSelectLR == true)
            {
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
        }
    }

    void FixedUpdate()
    {
        // �y�[�W�̏�Ԃ��X�V����
        PageState();

        // �y�[�W�̏�Ԃ��O��ƈႤ�ꍇ
        if (setStateL != statebookL && setStateR != statebookR)
        {
            selectPageL = false;
            selectPageR = false;
        }
        else
        {
            // �I���������ɂ���y�[�W���߂���
            if (PhasePageMove == true)
            {
                #region//�y�[�W�������ɂȂ�悤�ɂ��鏈��
                // transform���擾
                Transform shaft1Transform = Shaft1.transform;
                Transform shaft2Transform = Shaft2.transform;
                Transform shaft3Transform = Shaft3.transform;
                // ���[�J�����W����ɁA��]���擾
                Vector3 shaft1Angle = shaft1Transform.localEulerAngles;
                Vector3 shaft2Angle = shaft2Transform.localEulerAngles;
                Vector3 shaft3Angle = shaft3Transform.localEulerAngles;

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
                #endregion

                // L�{�^���������ꂽ�Ƃ��ɍ��ɂ���y�[�W�𓮂�����
                // stateBook�Ŗ{�̏�Ԃ𔻒�BpageMove�œ����Ă���y�[�W������̂�����
                if (selectPageL == true)
                {
                    // �y�[�W�P
                    if (statebookL == 1 && statebookR == 2)
                    {
                        if (pageMove2 == false && pageMove3 == false)
                        {
                            Page1Shaft_ON();
                        }
                    }
                    // �y�[�W�Q
                    else if (statebookL == 2 && statebookR == 3)
                    {
                        if (pageMove1 == false && pageMove3 == false)
                        {
                            Page2Shaft_ON();
                        }
                    }

                    else if (statebookL == 3 && statebookR == 4)
                    {
                        if (pageMove1 == false && pageMove2 == false)
                        {
                            Page3Shaft_ON();
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
                            Page1Shaft_ON();
                        }
                    }
                    // �y�[�W�Q
                    else if (statebookL == 1 && statebookR == 2)
                    {
                        if (pageMove1 == false && pageMove3 == false)
                        {
                            Page2Shaft_ON();
                        }
                    }

                    else if (statebookL == 2 && statebookR == 3)
                    {
                        if (pageMove1 == false && pageMove2 == false)
                        {
                            Page3Shaft_ON();
                        }
                    }
                }
            }
        }
    }

    // �y�[�W�̏�Ԃ��擾����֐�
    private void PageState()
    {
        // �v���C���[���n�ʂɂ���̂�����     false�Ȃ�n�ʂɂ���
        if (character.GetComponent<RayPlayer3>().DownCheck == false)
        {
            // �y�[�W�̏�Ԃ�ۑ����Ēu��
            setStateL = statebookL;
            setStateR = statebookR;
        }


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
        // �y�[�W�P�A�Q���{�̍��A�R���E�ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 2;
            statebookR = 3;
        }
        // �y�[�W�P�����A�y�[�W�Q�A�R���{�̉E�ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitR == true
            && PageHit3.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 1;
            statebookR = 2;
        }

        //********** �y�[�W�R������������� ********************
        // �y�[�W�P�A�Q�A�R���{�̍��ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitL == true
            && PageHit2.GetComponent<Pagehit>().ishitL == true
            && PageHit3.GetComponent<Pagehit>().ishitL == true)
        {
            statebookL = 3;
            statebookR = 4;
        }
        // �y�[�W�P�A�Q�����A�R���{�̉E�ɂ���ꍇ
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

    private void Page1Shaft_ON()
    {
        waku1.gameObject.SetActive(true);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft3>().enabled = true;
        Shaft2.GetComponent<PageShaft3>().enabled = false;
        Shaft3.GetComponent<PageShaft3>().enabled = false;
    }

    private void Page2Shaft_ON()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(true);
        waku3.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft3>().enabled = false;
        Shaft2.GetComponent<PageShaft3>().enabled = true;
        Shaft3.GetComponent<PageShaft3>().enabled = false;

    }

    private void Page3Shaft_ON()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(true);

        Shaft1.GetComponent<PageShaft3>().enabled = false;
        Shaft2.GetComponent<PageShaft3>().enabled = false;
        Shaft3.GetComponent<PageShaft3>().enabled = true;

    }

    private void ShahtAllOFF()
    {
        waku1.gameObject.SetActive(false);
        waku2.gameObject.SetActive(false);
        waku3.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft3>().enabled = false;
        Shaft2.GetComponent<PageShaft3>().enabled = false;
        Shaft3.GetComponent<PageShaft3>().enabled = false;
    }

}
