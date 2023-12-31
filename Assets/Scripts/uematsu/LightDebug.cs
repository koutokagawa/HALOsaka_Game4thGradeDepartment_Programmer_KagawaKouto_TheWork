using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        localAngle.x = -90.0f; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle.y = 0.0f; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle.z = 0.0f; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform.localEulerAngles = localAngle; // 回転角度を設定  }

    }
        // Update is called once per frame
        void Update()
    {
       
    }
}
