using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    public BoxCollider otherCollider;
    private bool isColliding;

    // Inspector�ŃV�[������ݒ�ł���悤�ɂ���
    public string sceneName;

    void Update()
    {
        if (isColliding && Gamepad.current.aButton.wasPressedThisFrame)
        {
            LoadScene(sceneName);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider == otherCollider)
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider == otherCollider)
        {
            isColliding = false;
        }
    }

    // LoadSceneAsync�̑����LoadScene���g�p����
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
