using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode pauseButton;
    public static bool IsGamePaused { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            if (!IsGamePaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public static void Pause()
    {
        Time.timeScale = 0;
        IsGamePaused = true;
    }

    public static void Unpause()
    {
        Time.timeScale = 1;
        IsGamePaused = false;
    }
}
