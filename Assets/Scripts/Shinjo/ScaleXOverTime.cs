using System;
using UnityEngine;

public class ScaleXOverTime : MonoBehaviour
{
    [SerializeField] private float targetScaleX = 2f; // �g�傷��Ƃ��̖ڕWX�X�P�[��
    [SerializeField] private float duration = 1f; // �X�P�[�����O����������܂ł̎���
    [SerializeField] private bool scaleUp = true; // �g�傷��ꍇ��true�A�k������ꍇ��false
    [SerializeField] private float targetScaleXDown = 1f / 1555.501f; // �k������Ƃ��̖ڕWX�X�P�[��

    private Vector3 startScale; // �X�P�[�����O�J�n���̃X�P�[��
    private float startTime; // �X�P�[�����O�̊J�n����
    private bool hasReachedTarget = false; // �ڕW�X�P�[���ɒB�������ǂ���
    private Action onScalingComplete; // �X�P�[�����O�������̃A�N�V����

    // �X�P�[�����O���J�n����
    public void BeginScaling(Action onScalingComplete, bool scaleUp)
    {
        this.onScalingComplete = onScalingComplete; // �X�P�[�����O�������̃A�N�V������ݒ�
        this.scaleUp = scaleUp; // �X�P�[�����O������ݒ�
        OnEnable(); // �X�P�[�����O���J�n
    }

    // �X�P�[�����O���J�n���邽�߂̏�����
    private void OnEnable()
    {
        startScale = transform.localScale; // �J�n�X�P�[�������݂̃X�P�[���ɐݒ�
        startTime = Time.time; // �J�n���Ԃ����݂̎��Ԃɐݒ�
        hasReachedTarget = false; // �ڕW�ɒB�����t���O��������
    }

    // ���t���[���Ăяo�����Unity�̊֐�
    private void Update()
    {
        if (hasReachedTarget) return; // �ڕW�ɒB���Ă���Ή������Ȃ�

        float elapsedTime = Time.time - startTime; // �o�ߎ��Ԃ��v�Z
        float progress = elapsedTime / duration; // �i�����v�Z

        if (progress >= 1f) // �i����100%�ɒB������
        {
            progress = 1f;
            hasReachedTarget = true; // �ڕW�ɒB�����ƃt���O�𗧂Ă�
            this.enabled = false; // �X�N���v�g�𖳌���

            if (onScalingComplete != null) // �X�P�[�����O�������̃A�N�V�������ݒ肳��Ă����
            {
                onScalingComplete.Invoke(); // ��������s
                //Time.timeScale = 0;
            }
        }

        // �V����X�X�P�[�����v�Z
        float newScaleX = scaleUp ? Mathf.Lerp(startScale.x, targetScaleX, progress) : Mathf.Lerp(startScale.x, targetScaleXDown, progress);
        Vector3 newScale = new Vector3(newScaleX, startScale.y, startScale.z); // �V�����X�P�[�����쐬
        transform.localScale = newScale; // �V�����X�P�[����K�p
    }
}
