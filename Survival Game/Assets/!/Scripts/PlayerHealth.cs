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
        StartCoroutine("Heal");
    }

    void Update()
    {
        _hpImage.fillAmount = (float)_playerStats.CurrentHP.Value / _playerStats.MaxHP.Value;
        Die();
    }

    public override void TakeDamage(float damage)
    {
        _playerStats.CurrentHP.Value -= damage;
    }

    protected override void Die()
    {
        if (_playerStats.CurrentHP.Value <= 0)
        {
            SceneManager.LoadScene("Main");
            Timer timer = FindFirstObjectByType<Timer>();
            timer.OnSaveTime();
        }
    }

    IEnumerator Heal()
    {
        while (true)
        {
            if (_playerStats.CurrentHP.Value <= _playerStats.MaxHP.Value)
            {
                _playerStats.CurrentHP.Value += _playerStats.HealthRegen.Value;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
