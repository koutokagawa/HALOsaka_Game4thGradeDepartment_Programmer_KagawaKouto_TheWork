using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHitONOFF : MonoBehaviour
{
    // 1�t���[���O�̈ʒu
    Vector3 Pos;
    public BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ����x��ۑ�
        Vector3 tmp = this.transform.position;
        // �����Ă���Ԃ͓����蔻�������
        if (Pos != tmp)
        {
            col.enabled = false;

            Pos = tmp;
        }
        else
        {
            col.enabled = true;
        }
    }
}
