using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    [SerializeField] Text valueText;

    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    }
}
