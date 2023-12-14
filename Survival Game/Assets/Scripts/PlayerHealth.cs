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

        if(_currentHP == 0)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
