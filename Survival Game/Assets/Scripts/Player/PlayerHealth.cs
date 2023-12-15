using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] private Image _hpImage;

    void Update()
    {
        _hpImage.fillAmount = _currentHP / _maxHP;
        Die();
    }

    protected override void Die()
    {
        if (_currentHP <= 0)
        {
            SceneManager.LoadScene("Main");
            Timer timer = FindFirstObjectByType<Timer>();
            timer.OnSaveTime();
        }
    }
}
