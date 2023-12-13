using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _currentHP;
    [SerializeField] private Image _hpImage;

    void Start()
    {
        
    }

    void Update()
    {
        _hpImage.fillAmount = _currentHP / _maxHP;

        if(_currentHP == 0)
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
    }
}
