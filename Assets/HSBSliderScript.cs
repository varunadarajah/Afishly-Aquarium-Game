using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HSBSliderScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Slider hueSlider;
    public Slider saturationSlider;
    public Slider brightnessSlider;
    public TMP_Text hexText;

    public Image saturationSliderColor;
    public Image brightnessSliderColor;

    public void onEdit() {
        float hueValue = hueSlider.value; // Value between 0 and 1
        float saturationValue = saturationSlider.value; // Value between 0 and 1
        float brightnessValue = brightnessSlider.value; // Value between 0 and 1

        Color color = Color.HSVToRGB(hueValue, saturationValue, brightnessValue);
        spriteRenderer.color = color;

        saturationSliderColor.color = Color.HSVToRGB(hueValue, 1, 1);
        brightnessSliderColor.color = Color.HSVToRGB(hueValue, 1, 1);

        // Convert color to hexadecimal string
        string hexString = ColorUtility.ToHtmlStringRGB(color);
        // Update text field with hexadecimal string
        hexText.text = "#" + hexString;
    }
}