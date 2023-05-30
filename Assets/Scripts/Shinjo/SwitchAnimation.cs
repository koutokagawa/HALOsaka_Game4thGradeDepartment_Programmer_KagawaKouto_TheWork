using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchAnimation : MonoBehaviour
{
    public GameObject scriptHolder; // �L�����������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject ScriptToActivate; // �L�����������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject StageSelectCube; // �L�����������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject ScriptToDeactivate; // �������������X�N���v�g�������Ă���I�u�W�F�N�g
    public GameObject RotatePage2; // �������������X�N���v�g�������Ă���I�u�W�F�N�g


    public Animator animator;  // Animator�R���g���[���[�̎Q��
    public string forwardAnimation = "AnimationName";  // ���Đ��A�j���[�V�����̖��O
    public string reverseAnimation = "ReverseAnimationName";  // �t�Đ��A�j���[�V�����̖��O

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

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
                StageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
                RotatePage2.GetComponent<RotatePage2>().enabled = false;
                // �X�N���v�g��L���ɂ���
                var script = scriptHolder.GetComponent<Parents>(); // <MonoBehaviour>�ɂ͗L�����������X�N���v�g�̌^����͂��܂�
                if (script != null)
                {
                    script.enabled = true;
                }
                animator.Play(reverseAnimation);
            }
        }
    }
}
