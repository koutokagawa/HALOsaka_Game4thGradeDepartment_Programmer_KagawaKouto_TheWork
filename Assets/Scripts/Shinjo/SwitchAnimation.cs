using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class SwitchAnimation : MonoBehaviour
{
    public GameObject scriptHolder; // 有効化したいスクリプトを持っているオブジェクト
    public GameObject ScriptToActivate; // 有効化したいスクリプトを持っているオブジェクト
    public GameObject StageSelectCube; // 有効化したいスクリプトを持っているオブジェクト
    public GameObject ScriptToDeactivate; // 無効化したいスクリプトを持っているオブジェクト
    public GameObject RotatePage2; // 無効化したいスクリプトを持っているオブジェクト
    public GameObject RotatePage3; // 無効化したいスクリプトを持っているオブジェクト
    public GameObject RotatePage4; // 無効化したいスクリプトを持っているオブジェクト

    public Animator animator;  // Animatorコントローラーの参照
    public string forwardAnimation = "AnimationName";  // 順再生アニメーションの名前
    public string reverseAnimation = "ReverseAnimationName";  // 逆再生アニメーションの名前

    public string sceneToLoad;


    // カメラの新しい位置
    private Vector3 newCameraPosition = new Vector3(-0.7f, 27.4f, 106.9f);
    // 移動時間
    private float moveDuration = 2f;
    // カメラ参照
    [SerializeField] private Camera mainCamera;

    private bool reverseAnimationCompleted = false;  // 逆再生アニメーションが完了したかどうかを追跡するフラグ

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 逆再生アニメーションが完了した場合
        if (stateInfo.IsName(reverseAnimation) && stateInfo.normalizedTime >= 1 && !reverseAnimationCompleted)
        {
            reverseAnimationCompleted = true;
            StageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
            SceneManager.LoadScene(sceneToLoad);
        }

        // 逆再生アニメーションが再生中の場合、フラグをリセットする
        if (stateInfo.IsName(reverseAnimation) && stateInfo.normalizedTime < 1)
        {
            reverseAnimationCompleted = false;
        }

        // 現在のアニメーションが完了している場合のみ再生方向を切り替えます
        if (stateInfo.normalizedTime >= 1)
        {
            // Aボタンが押されたときを検出します
            if (Gamepad.current.aButton.wasPressedThisFrame)
            {
                animator.Play(forwardAnimation);
                ScriptToActivate.GetComponent<SceneController>().enabled = true;
            }
            // Bボタンが押されたときを検出します
            else if (Gamepad.current.bButton.wasPressedThisFrame)
            {

                ScriptToDeactivate.GetComponent<SceneController>().enabled = false;
                RotatePage2.GetComponent<RotatePage2>().enabled = false;
                RotatePage3.GetComponent<RotatePage3>().enabled = false;
                RotatePage4.GetComponent<RotatePage4>().enabled = false;

                // スクリプトを有効にする
                var script = scriptHolder.GetComponent<Parents>(); // <MonoBehaviour>には有効化したいスクリプトの型を入力します
                if (script != null)
                {
                    script.enabled = true;
                }
                animator.Play(reverseAnimation);

                StartCoroutine(MoveCameraToPosition(mainCamera, newCameraPosition, moveDuration));
            }
        }
    }


    // カメラを指定位置に移動させるコルーチン
    private IEnumerator MoveCameraToPosition(Camera camera, Vector3 newPosition, float duration)
    {
        Vector3 startPosition = camera.transform.position; // 開始位置
        float startTime = Time.time; // 開始時間

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            camera.transform.position = Vector3.Lerp(startPosition, newPosition, t);
            yield return null;
        }

        // 移動完了
        camera.transform.position = newPosition;
        StageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
    }
}
