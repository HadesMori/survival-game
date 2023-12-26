using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    [SerializeField] private StatModifier _statModifier;
    [SerializeField] private StatType _statType;
    private LevelUpPanel _levelUpUI;
    private Button _button;
    private PlayerStats _playerStats;

    private void Start()
    {
        _playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        _levelUpUI = GameObject.Find("LevelUpUI").GetComponent<LevelUpPanel>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(_levelUpUI.ContinueGame);
    }

    public void OnClickModify()
    {
        _playerStats.Stats[(int)_statType].AddModifier(_statModifier);
    }
}
