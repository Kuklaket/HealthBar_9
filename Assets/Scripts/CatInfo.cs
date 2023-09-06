using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CatInfo : MonoBehaviour
{
    [SerializeField] private AudioSource _purring;
    [SerializeField] private AudioSource _furious;

    public static Action<float> onTouched;

    private bool _isChangedHealth;
    private float _health;
    private float _healthUpdateCount;
    private float _healthMax;
    private float _healthMin;
    private Coroutine _changeHealthTimer;

    void Start()
    {
        _isChangedHealth = false;
        _healthUpdateCount = 10f;
        _healthMax = 100f;
        _healthMin = 0f;
        _health = _healthMax;
        _changeHealthTimer = StartCoroutine(ChangeHealthTimer());
    }

    public void UpdateAdd()
    {
        float preMaxHeal = 90f;

        if (_health < _healthMax && !_isChangedHealth)
        {
            if (_changeHealthTimer != null)
            {
                StopCoroutine(_changeHealthTimer);
            }

            StartCoroutine(ChangeHealthTimer());

            if (_health > preMaxHeal)
            {
                _health = _healthMax;
            }
            else
            {
                _health += _healthUpdateCount;
                onTouched?.Invoke(_health);
            }

            _purring.Play();
        }        
    }

    public void UpdateRemove()
    {
        if (_health > _healthMin && !_isChangedHealth)
        {
            if (_changeHealthTimer != null)
            {
                StopCoroutine(_changeHealthTimer);
            }

            StartCoroutine(ChangeHealthTimer());

            _health -= _healthUpdateCount;
            onTouched?.Invoke(_health);
            _furious.Play();
        }            
    }
     
    private IEnumerator ChangeHealthTimer ()
    {
        _isChangedHealth = true;
        int timeInSeconds = 3;

        yield return new WaitForSeconds(timeInSeconds);

        _isChangedHealth = false;
    }
}
