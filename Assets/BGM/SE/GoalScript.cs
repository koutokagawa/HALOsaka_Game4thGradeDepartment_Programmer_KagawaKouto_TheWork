using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public AudioClip goalSound; // �S�[����SE����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[�I�u�W�F�N�g���S�[���ɐڐG�����ꍇ
        {
            AudioSource.PlayClipAtPoint(goalSound, transform.position); // SE���Đ�����
        }
    }
}
