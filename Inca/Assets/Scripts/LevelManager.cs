using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinuePlaying()
    {
        Pause pause = FindObjectOfType<Pause>();
        if (!pause)
        {
            Debug.LogWarning("Pause Script is missing from player");
            return;
        }
        pause.ManagePause();
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int numberOfScenes = SceneManager.sceneCountInBuildSettings;

        if(currentSceneIndex < numberOfScenes - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            LoadMenu();
        }


    }

}
