using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    void Update()
    {
        _canvas.gameObject.SetActive(GameManager.IsGamePaused);
    }
}
