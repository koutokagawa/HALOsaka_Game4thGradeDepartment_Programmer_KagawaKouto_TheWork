using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    public string sceneToLoad;

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
