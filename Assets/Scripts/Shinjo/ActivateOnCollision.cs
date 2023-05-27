using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;


public class ActivateOnCollision : MonoBehaviour
{
    [Header("ロードするシーン名")]
    public string sceneName;

    // 有効化するオブジェクトをインスペクタからアサインできるようにするための変数
    //public GameObject objectToActivate;

    // 特定のオブジェクトと衝突したときにオブジェクトを有効化するためのタグ
    public string targetTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが指定したタグと一致する場合
        if (collision.gameObject.CompareTag(targetTag))
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
