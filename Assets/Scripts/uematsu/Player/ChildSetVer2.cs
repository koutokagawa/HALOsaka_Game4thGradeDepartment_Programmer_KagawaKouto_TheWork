using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSetVer2 : MonoBehaviour
{
    private string Hitobj;
    private string Setobj;

    // 1�t���[���O�̈ʒu
    Vector3 Pos;
    public CapsuleCollider col;
    public PlayerUp character;
    public ShaftManagerVer2 Shaft;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RayHitObjTopUnder")
        {
            this.gameObject.transform.parent = other.gameObject.transform;
        }
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        // ���X�e�B�b�N
        float LstickX = Input.GetAxis("LstickX");
        float LstickY = Input.GetAxis("LstickY");

        // �S�Ẵy�[�W�������Ă��Ȃ��ꍇ
        if (Shaft.GetComponent<ShaftManagerVer2>().pageMove1 == false
             && Shaft.GetComponent<ShaftManagerVer2>().pageMove2 == false)
        {
            // �v���C���[���ނ�グ���Ă��Ȃ��ꍇ�A�����蔻���t����
            if (character.GetComponent<PlayerUp>().MaxUp == false)
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
    }
}
