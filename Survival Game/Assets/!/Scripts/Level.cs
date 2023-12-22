using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _progressBar;
    [SerializeField] private int _maxExp;
    private int _level;
    private int _currentExp;
    
    void Start()
    {
        _level = 0;
        _currentExp = 0;
    }

    void Update()
    {
        WriteLevel();
        LevelUp();
    }

    private void LevelUp()
    {
        if(_currentExp >= _maxExp)
        {
            _level++;
            _maxExp++;
            _currentExp = 0;
        }
    }

    private void WriteLevel()
    {
        _levelText.text = _level.ToString();
        _progressBar.fillAmount = (float)_currentExp / _maxExp;
    }

    public void Increase(int value)
    {
        _currentExp++;
    }
}
