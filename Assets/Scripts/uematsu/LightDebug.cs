using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // transform���擾
        Transform myTransform = this.transform;

        // ���[�J�����W����ɁA��]���擾
        Vector3 localAngle = myTransform.localEulerAngles;
        localAngle.x = -90.0f; // ���[�J�����W����ɁAx�������ɂ�����]��10�x�ɕύX
        localAngle.y = 0.0f; // ���[�J�����W����ɁAy�������ɂ�����]��10�x�ɕύX
        localAngle.z = 0.0f; // ���[�J�����W����ɁAz�������ɂ�����]��10�x�ɕύX
        myTransform.localEulerAngles = localAngle; // ��]�p�x��ݒ�  }

    }
        // Update is called once per frame
        void Update()
    {
       
    }
}
