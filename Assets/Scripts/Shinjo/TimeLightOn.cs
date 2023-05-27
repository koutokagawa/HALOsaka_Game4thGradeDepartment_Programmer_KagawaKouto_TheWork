using System.Collections;
using UnityEngine;

public class TimeLightOn : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public CameraController cameraController; // �ǉ�: CameraController�ւ̎Q��
    private int repeatCount;

    private void Start()
    {
        repeatCount = objectsToActivate.Length;
        StartCoroutine(PerformActionWithDelay());
    }

    private IEnumerator PerformActionWithDelay()
    {
        yield return new WaitForSeconds(1f); // 1�b��ɊJ�n

        for (int i = 0; i < repeatCount; i++)
        {
            // �I�u�W�F�N�g��L����
            objectsToActivate[i].SetActive(true);
            //Debug.Log("�I�u�W�F�N�g" + (i + 1) + "��L����");

            if (i < repeatCount - 1)
            {
                yield return new WaitForSeconds(1f); // ���̃I�u�W�F�N�g��L��������܂�1�b�ҋ@
            }
        }

        yield return new WaitForSeconds(1f); // �ǉ�: ���ׂẴI�u�W�F�N�g���L�������ꂽ��A1�b�ҋ@

        // �ǉ�: 1�b��ɃJ���������ɓ������܂�
        cameraController.StartCameraMove();
    }
}
