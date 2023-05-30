using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchAnimation : MonoBehaviour
{
    public GameObject scriptHolder; // 有効化したいスクリプトを持っているオブジェクト
    public GameObject ScriptToActivate; // 有効化したいスクリプトを持っているオブジェクト
    public GameObject StageSelectCube; // 有効化したいスクリプトを持っているオブジェクト
    public GameObject ScriptToDeactivate; // 無効化したいスクリプトを持っているオブジェクト
    public GameObject RotatePage2; // 無効化したいスクリプトを持っているオブジェクト


    public Animator animator;  // Animatorコントローラーの参照
    public string forwardAnimation = "AnimationName";  // 順再生アニメーションの名前
    public string reverseAnimation = "ReverseAnimationName";  // 逆再生アニメーションの名前

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

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
                StageSelectCube.GetComponent<Cursolstageselect>().enabled = true;
                RotatePage2.GetComponent<RotatePage2>().enabled = false;
                // スクリプトを有効にする
                var script = scriptHolder.GetComponent<Parents>(); // <MonoBehaviour>には有効化したいスクリプトの型を入力します
                if (script != null)
                {
                    script.enabled = true;
                }
                animator.Play(reverseAnimation);
            }
        }
    }
}
