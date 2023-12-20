using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _recordTimeText;
    private float _elapsedTime = 0;
    private float _recordTime = 0;

    private void Start()
    {
        _recordTime = PlayerPrefs.GetFloat("recordTime");
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        SetTimeText(_elapsedTime, _timerText);
        SetTimeText(_recordTime, _recordTimeText);
    }

    private void SetTimeText(float time, TextMeshProUGUI text)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnSaveTime()
    {
        if(_recordTime < _elapsedTime)
        {
            PlayerPrefs.SetFloat("recordTime", _elapsedTime);
        }
    }
}
