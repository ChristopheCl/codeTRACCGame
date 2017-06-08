using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* wanneer men op de pauze knop duwt wordt de tijd stil gezet (pauze) */
#endregion

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    isPaused = !isPaused;
        //}
    }

    public void Pause()
    {
        isPaused = !isPaused;
    }

    public void Resume()
    {
        isPaused = false;
    }
}
