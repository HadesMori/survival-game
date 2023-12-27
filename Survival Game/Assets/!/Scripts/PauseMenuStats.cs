using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenuStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _healthRegen;
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
        _health.text = $"{Mathf.Round(_playerStats.CurrentHP.Value)} / {Mathf.Round(_playerStats.MaxHP.Value)}";
        _healthRegen.text = _playerStats.HealthRegen.Value.ToString();
        _damage.text = Mathf.Round(_playerStats.Damage.Value).ToString();
        _attackSpeed.text = _playerStats.AttackSpeed.Value.ToString();
        _speed.text = Mathf.Round(_playerStats.Speed.Value).ToString();
    }
}
