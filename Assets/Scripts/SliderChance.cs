using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChance : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _sliderText;

    public static Action OnActivate;
    
    private float _changeValueCount;

    private void Start()
    {
        _changeValueCount = 10f;
        _slider.value = 100f;
    }

    private void MoveSlider(float health)
    {
        Coroutine changeHealth = StartCoroutine(ChangeHealth(health));
       
        if (changeHealth != null)
        {
            StopCoroutine(changeHealth);
        }

        OnActivate?.Invoke();
        StartCoroutine(ChangeHealth(health));
    }

    IEnumerator ChangeHealth(float health)
    {
        while (_slider.value != health) 
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _changeValueCount * Time.deltaTime);
            _sliderText.text = _slider.value.ToString();

            yield return null;
        }        
    }

    private void OnEnable()
    {
        CatInfo.OnTouched += MoveSlider;
    }

    private void OnDisable()
    {
        CatInfo.OnTouched -= MoveSlider;
    }
}
