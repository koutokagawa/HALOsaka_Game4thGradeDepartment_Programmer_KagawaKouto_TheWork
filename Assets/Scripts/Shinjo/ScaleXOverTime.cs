using System;
using UnityEngine;

public class ScaleXOverTime : MonoBehaviour
{
    [SerializeField] private float targetScaleX = 2f; // 拡大するときの目標Xスケール
    [SerializeField] private float duration = 1f; // スケーリングが完了するまでの時間
    [SerializeField] private bool scaleUp = true; // 拡大する場合はtrue、縮小する場合はfalse
    [SerializeField] private float targetScaleXDown = 1f / 1555.501f; // 縮小するときの目標Xスケール

    private Vector3 startScale; // スケーリング開始時のスケール
    private float startTime; // スケーリングの開始時間
    private bool hasReachedTarget = false; // 目標スケールに達したかどうか
    private Action onScalingComplete; // スケーリング完了時のアクション

    // スケーリングを開始する
    public void BeginScaling(Action onScalingComplete, bool scaleUp)
    {
        this.onScalingComplete = onScalingComplete; // スケーリング完了時のアクションを設定
        this.scaleUp = scaleUp; // スケーリング方向を設定
        OnEnable(); // スケーリングを開始
    }

    // スケーリングを開始するための初期化
    private void OnEnable()
    {
        startScale = transform.localScale; // 開始スケールを現在のスケールに設定
        startTime = Time.time; // 開始時間を現在の時間に設定
        hasReachedTarget = false; // 目標に達したフラグを初期化
    }

    // 毎フレーム呼び出されるUnityの関数
    private void Update()
    {
        if (hasReachedTarget) return; // 目標に達していれば何もしない

        float elapsedTime = Time.time - startTime; // 経過時間を計算
        float progress = elapsedTime / duration; // 進捗を計算

        if (progress >= 1f) // 進捗が100%に達したら
        {
            progress = 1f;
            hasReachedTarget = true; // 目標に達したとフラグを立てる
            this.enabled = false; // スクリプトを無効化

            if (onScalingComplete != null) // スケーリング完了時のアクションが設定されていれば
            {
                onScalingComplete.Invoke(); // それを実行
                //Time.timeScale = 0;
            }
        }

        // 新しいXスケールを計算
        float newScaleX = scaleUp ? Mathf.Lerp(startScale.x, targetScaleX, progress) : Mathf.Lerp(startScale.x, targetScaleXDown, progress);
        Vector3 newScale = new Vector3(newScaleX, startScale.y, startScale.z); // 新しいスケールを作成
        transform.localScale = newScale; // 新しいスケールを適用
    }
}
