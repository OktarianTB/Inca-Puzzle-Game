using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;
    public bool gameIsPaused = false;

    void Start()
    {
        if (!pausePanel)
        {
            Debug.LogWarning("Pause Panel is missing from Player Object");
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }

    public void ManagePause()
    {
        if (!pausePanel)
        {
            return;
        }
        gameIsPaused = !gameIsPaused;
        pausePanel.SetActive(gameIsPaused);
        Time.timeScale = gameIsPaused ? 0 : 1;
    }


}
