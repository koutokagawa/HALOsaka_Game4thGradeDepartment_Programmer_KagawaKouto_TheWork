using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndButtonAction : MonoBehaviour
{
    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        SceneManager.LoadScene("Title");
    }
}
