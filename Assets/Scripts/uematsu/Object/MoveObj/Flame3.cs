using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame3 : MonoBehaviour
{
    public GameObject obj;
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
        if (obj != null)
        {
            // オブジェクトの位置をobjと同じ位置にする
            flame.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);

            if (obj.GetComponent<MoveObj3>().flameHit == true)
            {
                flame.gameObject.SetActive(true);
                count += Time.deltaTime;

                // 経過時間が過ぎたらリセット
                if (count > 5.0f)
                {
                    Destroy(obj.gameObject);
                    Destroy(flame.gameObject);
                }
            }
        }
    }
}
