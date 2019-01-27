using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnPlayButton()
    {
        Debug.Log(SceneManager.sceneCount);
        if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestarButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
