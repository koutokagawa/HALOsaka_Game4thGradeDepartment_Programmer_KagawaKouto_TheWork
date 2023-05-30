using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchAnimation : MonoBehaviour
{

    [Header("切り離したい子オブジェクト")]          
    public GameObject[] children;


    public GameObject scriptHolder; // 有効化したいスクリプトを持っているオブジェクト


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
            }
            // Bボタンが押されたときを検出します
            else if (Gamepad.current.bButton.wasPressedThisFrame)
            {
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
