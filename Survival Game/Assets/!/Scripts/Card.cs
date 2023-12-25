using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour {

    [SerializeField] private StatModifier _statModifier;
    [SerializeField] private StatType _statType;
    private PlayerStats _playerStats;

    private void Start()
    {
        _playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void OnClickModify()
    {
        _playerStats.Stats[(int)_statType].AddModifier(_statModifier);
    }
}
