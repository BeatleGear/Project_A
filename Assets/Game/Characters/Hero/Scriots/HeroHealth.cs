using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

    public event Action<float> HealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            ChangeHeals(-10);
    }

    private void ChangeHeals(int value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0 )
            Death();
        
        //else if (_currentHealth >= 100)
        //    _currentHealth = 100;
        else
        {
            float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
            Debug.Log("Рассчитанный процент " + _currentHealthAsPercantage);
            HealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
    }
}
