using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public string targetTag = "Target"; // 移動させるオブジェクトのタグ
    public Transform destination; // 移動先の位置

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.transform.position = destination.position; // オブジェクトを移動させる
        }
    }
}
