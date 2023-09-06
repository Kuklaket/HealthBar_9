using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text valueText;

    public void OnSliderChanged(float value)
    {
        valueText.text = _slider.value.ToString();
    }    
}
