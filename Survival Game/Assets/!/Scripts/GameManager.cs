using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode pauseButton;
    public static bool IsGamePaused { get; private set; }

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
