using UnityEngine;

public class MoveCutainRight : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float moveDirection = 1f; // 1 for right, -1 for left

    private Vector3 startPosition;
    private float startTime;
    private bool hasReachedTarget = false;

    private void OnEnable()
    {
        startPosition = transform.position;
        startTime = Time.time;
        hasReachedTarget = false;
    }

    private void Update()
    {
        if (hasReachedTarget) return;

        float elapsedTime = Time.time - startTime;
        float progress = elapsedTime / duration;

        if (progress >= 1f)
        {
            progress = 1f;
            hasReachedTarget = true;
            this.enabled = false; // �X�N���v�g�𖳌���
        }

        Vector3 newPosition = Vector3.Lerp(startPosition, startPosition + new Vector3(moveDistance * moveDirection, 0, 0), progress);
        transform.position = newPosition;
    }

    private void OnDisable()
    {
        // �����Ń��Z�b�g��N���[���A�b�v���K�v�ȏ������s���܂��B
    }
}
