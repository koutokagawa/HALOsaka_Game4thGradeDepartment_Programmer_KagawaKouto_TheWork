using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public string targetTag = "Target"; // �ړ�������I�u�W�F�N�g�̃^�O
    public Transform destination; // �ړ���̈ʒu

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.transform.position = destination.position; // �I�u�W�F�N�g���ړ�������
        }
    }
}
