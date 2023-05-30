using System.Collections;
using UnityEngine;

public class StageBookAnimatorController : MonoBehaviour
{
    private Animator animator;
    private float animationLength;

    // Inspector上で設定するプレハブ化されたBookオブジェクトへの参照
    public GameObject stageBook;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            if (animator.runtimeAnimatorController != null &&
                animator.runtimeAnimatorController.name == "BookAnimation")
            {
                animator.enabled = true;
                animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

                StartCoroutine(EnableScriptsAfterAnimation());
            }
        }
    }

    IEnumerator EnableScriptsAfterAnimation()
    {
        yield return new WaitForSeconds(animationLength);

        SceneController sceneController = stageBook.GetComponent<SceneController>();
        Parentalseparation parentalSeparation = stageBook.GetComponent<Parentalseparation>();
        SwitchAnimation switchAnimation = stageBook.GetComponent<SwitchAnimation>();

        if (sceneController != null)
        {
            sceneController.enabled = true;
        }

        if (parentalSeparation != null)
        {
            parentalSeparation.enabled = true;
        }

        if (switchAnimation != null)
        {
            switchAnimation.enabled = true;
        }

        GameObject rotatePage2Obj = stageBook.transform.Find("RotatePage2").gameObject;
        if (rotatePage2Obj != null)
        {
            RotatePage2 rotatePage = rotatePage2Obj.GetComponent<RotatePage2>();
            if (rotatePage != null)
            {
                rotatePage.enabled = true;
            }
        }
    }
}
