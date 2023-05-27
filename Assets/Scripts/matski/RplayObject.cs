using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RplayObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("復活させるObjectを設定")]
    private GameObject Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject playerObj = GameObject.Find(Prefab.name);
        // playerObjが存在していない場合
        if (playerObj == null)
        {
            // playerPrefabから新しくGameObjectを作成
            GameObject newPlayerObj = Instantiate(Prefab);

            // 新しく作成したGameObjectの名前を再設定(今回は"PlayerSphere"となる)
            newPlayerObj.name = Prefab.name;
            // ※ここで名前を再設定しない場合、自動で決まる名前は、"PlayerSphere(Clone)"となるため
            //   13行目で探している"PlayerSphere"が永遠に見つからないことになり、playerが無限に生産される

        }
        }
    }
