using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] private Image _hpImage;
    private PlayerStats _playerStats;

    private void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        _hpImage.fillAmount = (float)_playerStats.CurrentHP / _playerStats.MaxHP;
        Die();
    }

    public override void TakeDamage(int damage)
    {
        _playerStats.CurrentHP -= damage;
    }

    protected override void Die()
    {
        if (_playerStats.CurrentHP <= 0)
        {
            SceneManager.LoadScene("Main");
            Timer timer = FindFirstObjectByType<Timer>();
            timer.OnSaveTime();
        }
    }
}
