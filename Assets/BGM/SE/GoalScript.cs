using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public AudioClip goalSound; // ゴールのSE音源

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーオブジェクトがゴールに接触した場合
        {
            AudioSource.PlayClipAtPoint(goalSound, transform.position); // SEを再生する
        }
    }
}
