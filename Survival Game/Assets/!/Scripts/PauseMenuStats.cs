using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenuStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private TextMeshProUGUI _attackSpeed;
    [SerializeField] private TextMeshProUGUI _speed;

    private PlayerStats _playerStats;

    void Start()
    {
        _playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        _health.text = $"{_playerStats.CurrentHP} / {_playerStats.MaxHP}";
        _damage.text = _playerStats.Damage.ToString();
        _attackSpeed.text = _playerStats.AttackSpeed.ToString();
        _speed.text = _playerStats.Speed.ToString();
    }
}
