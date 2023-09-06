using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Text valueText;

    public void OnSliderChanged(float value)
    {
        valueText.text = Slider.value.ToString();

    }    


}
