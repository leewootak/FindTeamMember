using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public bool isPaused = false;

    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;

            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;

            isPaused = false;
        }
    }

}
