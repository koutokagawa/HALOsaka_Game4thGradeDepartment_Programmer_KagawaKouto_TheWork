using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public Pagehit hitpage;
    //���I�u�W�F�N�g�Q�Ɨp



    void OnCollisionStay(Collision collision)
    {

        //if (collision.gameObject.name == "Re_book")//���������I�u�W�F�N�g��book_a�Ȃ珈������
        //{
        //    // UnityEngine.Debug.Log("�������Ă���");
        //    if (hitpage.GetComponent<Pagehit>().isCubeHit == true)//MObjectMove�X�N���v�g��isCubeHit���Q�Ƃ���
        //    {
        //        Destroy(gameObject);//���̃X�N���v�g���������I�u�W�F�N�g������
        //    }
        //}
    }

    //void OnTriggerExit(Collider other)
    //{
    //    UnityEngine.Debug.Log("�ʂ蔲���I����");
    //}

    // Start is called before the first frame update
    void Start()
    {
      //  hitpage = GameObject.Find("page");//�Q�Ƃ���I�u�W�F�N�g���w�肷��
    }

    // Update is called once per frame
    void Update()
    {



    }
}
