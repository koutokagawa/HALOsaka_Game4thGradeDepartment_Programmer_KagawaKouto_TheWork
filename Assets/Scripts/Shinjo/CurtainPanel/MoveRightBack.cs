using UnityEngine;

public class MoveRightBack : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float duration = 1f;

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
            this.enabled = false; // スクリプトを無効化
        }

        Vector3 newPosition = Vector3.Lerp(startPosition, startPosition - new Vector3(moveDistance, 0, 0), progress);
        transform.position = newPosition;
    }

    private void OnDisable()
    {
        // ここでリセットやクリーンアップが必要な処理を行います。
    }
}
