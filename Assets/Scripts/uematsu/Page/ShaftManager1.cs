using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager1 : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�P�y�[�W��pageshaft������")] public GameObject Shaft1;
    [Header("�P�y�[�W��pageHit������")] public Pagehit PageHit1;

    [Header("�P�y�[�W�̌���g������")] public GameObject waku1;

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

    void Start()
    {
        waku1.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft>().enabled = false;

        // �I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
        Shaft1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
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
                // ���[�J�����W����ɁA��]���擾
                Vector3 shaft1Angle = shaft1Transform.localEulerAngles;

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
                #endregion

                // L�{�^���������ꂽ�Ƃ��ɍ��ɂ���y�[�W�𓮂�����
                // stateBook�Ŗ{�̏�Ԃ𔻒�BpageMove�œ����Ă���y�[�W������̂�����
                if (selectPageL == true)
                {
                    // �y�[�W�P
                    if (statebookL == 1 && statebookR == 2)
                    {
                        Page1Shaft_ON();
                    }
                }

                // R�{�^���������ꂽ�Ƃ��ɉE�ɂ���y�[�W�𓮂�����
                // stateBook�Ŗ{�̏�Ԃ𔻒�BpageMove�œ����Ă���y�[�W������̂�����
                if (selectPageR == true)
                {
                    // �y�[�W�P
                    if (statebookL == 0 && statebookR == 1)
                    {
                        Page1Shaft_ON();
                    }
                }
            }
        }   
    }

    // �y�[�W�̏�Ԃ��擾����֐�
    private void PageState()
    {
        // �v���C���[���n�ʂɂ���̂�����     false�Ȃ�n�ʂɂ���
        if (character.GetComponent<RayPlayer>().DownCheck == false)
        {
            // �y�[�W�̏�Ԃ�ۑ����Ēu��
            setStateL = statebookL;
            setStateR = statebookR;
        }

        #region//���݂̃y�[�W�̏�Ԃ𔻒f
        //********** �y�[�W�P������������� ********************
        // �y�[�W�P���{�̉E�ɂ���ꍇ
        if (PageHit1.GetComponent<Pagehit>().ishitR == true)
        {
            statebookL = 0;
            statebookR = 1;
        }
        // �y�[�W�P���{�̍��ɂ���ꍇ
        else if (PageHit1.GetComponent<Pagehit>().ishitL == true)
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

        // �y�[�W���{�̍��E�ǂ��炩�ɓ������Ă���̂�
        if (PageHit1.GetComponent<Pagehit>().ishitL == true && PageHit1.GetComponent<Pagehit>().ishitR == false
            || PageHit1.GetComponent<Pagehit>().ishitL == false && PageHit1.GetComponent<Pagehit>().ishitR == true)
        {
            phaseSelectLR = true;
            pageMove1 = false;
        }
        #endregion
    }

    private void Page1Shaft_ON()
    {
        waku1.gameObject.SetActive(true);

        Shaft1.GetComponent<PageShaft>().enabled = true;
    }

    private void ShahtAllOFF()
    {
        waku1.gameObject.SetActive(false);

        Shaft1.GetComponent<PageShaft>().enabled = false;
    }
}