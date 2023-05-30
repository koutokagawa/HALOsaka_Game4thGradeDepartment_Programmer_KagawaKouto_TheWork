using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerScaleAndCameraMove : MonoBehaviour
{
    // ScaleXOverTime �X�N���v�g���Q�Ƃ���
    public GameObject objectToScaleLeft;
    public GameObject objectToScaleRight;
    [SerializeField] private GameObject stageSelectCube;


    private int finishedScalingCount = 0;


    // �J�����̐V�����ʒu
    private Vector3 newCameraPosition = new Vector3(-0.7f, 27.4f, 106.9f);
    // �ړ�����
    private float moveDuration = 1f;
    // �J�����Q��
    [SerializeField] private Camera mainCamera;

    // Update is called once per frame
    private void Update()
    {
        // A�{�^���������ꂽ��AScaleXOverTime��BeginScaling���Ăяo���A�X�P�[�����O���J�n���A�J�������ړ�����
        if (Gamepad.current.aButton.wasPressedThisFrame)
        {
            // �I�u�W�F�N�g�̍��E��ScaleXOverTime�X�N���v�g��L�������Ď��s
            EnableAndRunScaleScript(objectToScaleLeft, false);
            EnableAndRunScaleScript(objectToScaleRight, false);
            StartCoroutine(MoveCameraToPosition(mainCamera, newCameraPosition, moveDuration));
        }
    }

    // �J�������w��ʒu�Ɉړ�������R���[�`��
    private IEnumerator MoveCameraToPosition(Camera camera, Vector3 newPosition, float duration)
    {
        Vector3 startPosition = camera.transform.position; // �J�n�ʒu
        float startTime = Time.time; // �J�n����

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            camera.transform.position = Vector3.Lerp(startPosition, newPosition, t);
            yield return null;
        }

        // �ړ�����
        camera.transform.position = newPosition;
    }

    private void EnableAndRunScaleScript(GameObject target, bool scaleUp)
    {
        ScaleXOverTime scaleXOverTime = target.GetComponent<ScaleXOverTime>();
        if (scaleXOverTime != null)
        {
            scaleXOverTime.enabled = true;
            scaleXOverTime.BeginScaling(OnScalingFinished, scaleUp);
        }
    }

    private void OnScalingFinished()
    {
        finishedScalingCount++;

        if (finishedScalingCount >= 2)
        {
            stageSelectCube.SetActive(true);
            stageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
        }
    }
}
