using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHitONOFF : MonoBehaviour
{
    // 1フレーム前の位置
    Vector3 Pos;
    public BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移動速度を保存
        Vector3 tmp = this.transform.position;
        // 動いている間は当たり判定を消す
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
