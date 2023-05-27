using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReSpawnObjectVer2 : MonoBehaviour
{
    // リスポーンさせるオブジェクトを入れる
    [Header("初期位置になるオブジェクト")]
    public GameObject posObj;

    [Header("復活させるオブジェクト")]
    public GameObject obj;

    [Header("親になるオブジェクト")]
    public GameObject parentObj;

    [Header("ページを開いた時のオブジェクトの位置")]
    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    private bool bookHit = true;

   
    void OnTriggerEnter(Collider other)
    {


    }

    void OnTriggerExit(Collider other)
    {
        if (ObjectPosL == false)
        {
            if (other.gameObject.tag == "bookR")
            {
                bookHit = false;
            }
        }

        if (ObjectPosR == false)
        {
            if (other.gameObject.tag == "bookL")
            {
                bookHit = false;
            }
        }


    }

    void Start()
    {
        // 新しく作成したオブジェクトの位置をobjと同じ位置にする
        obj.transform.position = new Vector3(posObj.transform.position.x, posObj.transform.position.y, posObj.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        // 復活させるオブジェクトが存在しない場合
        if (obj.activeInHierarchy == false)
        {
            // 本から離れた場合
            if (bookHit == false)
            {
                // オブジェクトを復活させる
                obj.gameObject.SetActive(true);

                // 新しく作成したオブジェクトの位置をobjと同じ位置にする
                obj.transform.position = new Vector3(posObj.transform.position.x, posObj.transform.position.y, posObj.transform.position.z);

                //parentObjの子オブジェクトに設定する
                obj.transform.parent = parentObj.transform;

                // 一度だけ実行するためにfalseにする
                bookHit = false;


            }
        }
    }
}
