using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MObjectMove : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    public PhysicMaterial Slip;
    public PhysicMaterial nonSlip;

    //�����������ǂ����̔���t���O
    public bool ishitL;
    public bool ishitR;
    public bool isCubeHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        
        //�ŏ���false�ɂ���
        ishitL = false;
        ishitR = false;
        isCubeHit = false;
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) { collider.material = Slip; }
        else
        {
            collider.material = nonSlip;
        }
        if(isCubeHit==true)
        {
            isCubeHit = false;
        }
        //if (Input.GetKey(KeyCode.RightArrow)) { collider.material = Slip; }
        //else
        //{
        //    collider.material = nonSlip;
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    time = 1;
        //    rb.AddForce(force, 0, 0, ForceMode.Impulse);
        //}

    }
    private void OnCollisionStay(Collision collision) //�ق��̃I�u�W�F�N�g�ƐڐG������Ăяo�����
    {

        if (collision.gameObject.name == "bookhitL")//�ڐG�����I�u�W�F�N�g��bookhitL�������珈�����s��
        {
            ishitL = true;
            //Debug.Log("��");
        }


        if (collision.gameObject.name == "bookhitR")//�ڐG�����I�u�W�F�N�g��bookhitR�������珈�����s��
        {
            ishitR = true;
            //Debug.Log("�E");
        }

        if (collision.gameObject.name=="Cube")//�ڐG�����I�u�W�F�N�g��Cube�������炾�����珈�����s��
        {

            isCubeHit = true;
        }
    }
    private void OnCollisionExit(Collision collision)//�ڐG������ɂ͂Ȃꂽ��Ăяo�����
    {
        if (collision.gameObject.name == "bookhitL")//bookhitL���痣�ꂽ�珈�����s��
        {
            ishitL = false;
            //Debug.Log("�����ꂽ");
        }


        if (collision.gameObject.name == "bookhitR")//bookhitR���痣�ꂽ�珈�����s��
        {
            ishitR = false;
            //Debug.Log("�E���ꂽ");
        }
        if (collision.gameObject.name == "Cube")//cube���痣�ꂽ�珈�����s��
        {
            isCubeHit = false;
        }

    }
}