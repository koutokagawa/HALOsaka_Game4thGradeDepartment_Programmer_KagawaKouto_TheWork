using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class SwitchAnimation : MonoBehaviour
{
    public GameObject scriptHolder; // �L�����������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject ScriptToActivate; // �L�����������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject StageSelectCube; // �L�����������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject ScriptToDeactivate; // �������������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject RotatePage2; // �������������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject RotatePage3; // �������������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject RotatePage4; // �������������X�N���v�g�������Ă���I�u�W�F�N�g

    public Animator animator;  // Animator�R���g���[���[�̎Q��
    public string forwardAnimation = "AnimationName";  // ���Đ��A�j���[�V�����̖��O
    public string reverseAnimation = "ReverseAnimationName";  // �t�Đ��A�j���[�V�����̖��O

    public string sceneToLoad;


    // �J�����̐V�����ʒu
    private Vector3 newCameraPosition = new Vector3(-0.7f, 27.4f, 106.9f);
    // �ړ�����
    private float moveDuration = 2f;
    // �J�����Q��
    [SerializeField] private Camera mainCamera;

    private bool reverseAnimationCompleted = false;  // �t�Đ��A�j���[�V�����������������ǂ�����ǐՂ���t���O

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // �t�Đ��A�j���[�V���������������ꍇ
        if (stateInfo.IsName(reverseAnimation) && stateInfo.normalizedTime >= 1 && !reverseAnimationCompleted)
        {
            reverseAnimationCompleted = true;
            StageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
            SceneManager.LoadScene(sceneToLoad);
        }

        // �t�Đ��A�j���[�V�������Đ����̏ꍇ�A�t���O�����Z�b�g����
        if (stateInfo.IsName(reverseAnimation) && stateInfo.normalizedTime < 1)
        {
            reverseAnimationCompleted = false;
        }

        // ���݂̃A�j���[�V�������������Ă���ꍇ�̂ݍĐ�������؂�ւ��܂�
        if (stateInfo.normalizedTime >= 1)
        {
            // A�{�^���������ꂽ�Ƃ������o���܂�
            if (Gamepad.current.aButton.wasPressedThisFrame)
            {
                animator.Play(forwardAnimation);
                ScriptToActivate.GetComponent<SceneController>().enabled = true;
            }
            // B�{�^���������ꂽ�Ƃ������o���܂�
            else if (Gamepad.current.bButton.wasPressedThisFrame)
            {

                ScriptToDeactivate.GetComponent<SceneController>().enabled = false;
                RotatePage2.GetComponent<RotatePage2>().enabled = false;
                RotatePage3.GetComponent<RotatePage3>().enabled = false;
                RotatePage4.GetComponent<RotatePage4>().enabled = false;

                // �X�N���v�g��L���ɂ���
                var script = scriptHolder.GetComponent<Parents>(); // <MonoBehaviour>�ɂ͗L�����������X�N���v�g�̌^����͂��܂�
                if (script != null)
                {
                    script.enabled = true;
                }
                animator.Play(reverseAnimation);

                StartCoroutine(MoveCameraToPosition(mainCamera, newCameraPosition, moveDuration));
            }
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
        StageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
    }
}
