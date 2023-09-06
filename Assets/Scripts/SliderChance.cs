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

    private void Update()
    {
        _sliderText.text = _slider.value.ToString();
    }

    private void MoveSlider(float health)
    {
        OnActivate?.Invoke();
        StartCoroutine(ChangeHealth(health));
    }

    IEnumerator ChangeHealth(float health)
    {
        while (_slider.value != health) 
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _changeValueCount * Time.deltaTime);

            yield return null;
        }        
    }

    private void OnEnable()
    {
        CatInfo.onTouched += MoveSlider;
    }

    private void OnDisable()
    {
        CatInfo.onTouched -= MoveSlider;
    }
}
