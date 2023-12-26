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
    public bool IsLevelUpgraded;
    public int CurrentLevel { get; private set; }
    private int _currentExp;

    void Start()
    {
        CurrentLevel = 0;
        _currentExp = 0;
    }

    void Update()
    {
        WriteLevel();
        LevelUp();
    }

    public void LevelUp()
    {
        if (_currentExp >= _maxExp)
        {
            CurrentLevel++;
            _maxExp++;
            _currentExp = 0;
            IsLevelUpgraded = true;
        }
    }

    private void WriteLevel()
    {
        _levelText.text = CurrentLevel.ToString();
        _progressBar.fillAmount = (float)_currentExp / _maxExp;
    }

    public void Increase(int value)
    {
        _currentExp++;
    }
}
