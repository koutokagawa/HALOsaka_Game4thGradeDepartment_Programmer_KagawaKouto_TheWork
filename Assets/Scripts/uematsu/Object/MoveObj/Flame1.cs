using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame1 : MonoBehaviour
{
    public GameObject Obj;
    public GameObject flame; // 追従先オブジェクトのTransform

    public float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        flame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Obj != null)
        {
            // オブジェクトの位置をobjと同じ位置にする
            flame.transform.position = new Vector3(Obj.transform.position.x, Obj.transform.position.y, Obj.transform.position.z);

            if (Obj.GetComponent<MoveObj1>().flameHit == true)
            {
                flame.gameObject.SetActive(true);
                count += Time.deltaTime;

                // 経過時間が過ぎたらリセット
                if (count > 5.0f)
                {
                    Destroy(Obj.gameObject);
                    Destroy(flame.gameObject);
                }
            }
        }
    }
}
