using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HSBTesting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Slider hueSlider;
    public TMP_Text hexText;

    public Image SandBColor;

    private void Start()
    {
        // set color sliders
        SandBColor.color = Color.HSVToRGB(0, 1, 1);
    }

    public void onEdit() {
        float hueValue = hueSlider.value; // Value between 0 and 1

        Color color = Color.HSVToRGB(hueValue, 1, 1);
        spriteRenderer.color = color;

        SandBColor.color = Color.HSVToRGB(hueValue, 1, 1);

        // Convert color to hexadecimal string
        string hexString = ColorUtility.ToHtmlStringRGB(color);
        // Update text field with hexadecimal string
        hexText.text = "#" + hexString;
    }
}