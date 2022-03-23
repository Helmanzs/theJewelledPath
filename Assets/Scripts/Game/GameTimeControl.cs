using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeControl : MonoBehaviour
{
    private bool isPaused = false;

    public void StopGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void SpeedUpGame()
    {
        isPaused = false;
        Time.timeScale = 2f;
    }
}
