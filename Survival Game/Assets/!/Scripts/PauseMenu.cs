using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private KeyCode _pauseButton;
    [SerializeField] private Canvas _canvas;
    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(_pauseButton))
        {
            if(!GameManager.IsGamePaused && Time.timeScale == 0)
            {
                _canvas.gameObject.SetActive(isActive);
                isActive = !isActive;
            }
            else if(!GameManager.IsGamePaused && Time.timeScale == 1)
            {
                GameManager.Pause();
                _canvas.gameObject.SetActive(GameManager.IsGamePaused);
            }
            else if (GameManager.IsGamePaused && Time.timeScale == 0)
            {
                GameManager.Unpause();
                _canvas.gameObject.SetActive(GameManager.IsGamePaused);
            }
        }
    }
}
