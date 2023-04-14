using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RGBColorScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer redSpriteRenderer;
    public SpriteRenderer greenSpriteRenderer;
    public SpriteRenderer blueSpriteRenderer;
    public Slider red; 
    public Slider green;
    public Slider blue; 
    public TMP_Text rValueText;
    public TMP_Text gValueText;
    public TMP_Text bValueText;

    public void onEdit() {
        float redValue = red.value / 255f; // Divide by 255 to convert to 0-1 range
        float greenValue = green.value / 255f; // Divide by 255 to convert to 0-1 range
        float blueValue = blue.value / 255f; // Divide by 255 to convert to 0-1 range

        Color color = spriteRenderer.color; 
        color.r = redValue;
        color.g = greenValue;
        color.b = blueValue; 
        spriteRenderer.color = color;

        Color redColor = redSpriteRenderer.color;
        redColor.r = redValue;
        redColor.g = 0f;
        redColor.b = 0f;
        redSpriteRenderer.color = redColor;

        Color greenColor = greenSpriteRenderer.color;
        greenColor.r = 0f;
        greenColor.g = greenValue;
        greenColor.b = 0f;
        greenSpriteRenderer.color = greenColor;

        Color blueColor = blueSpriteRenderer.color;
        blueColor.r = 0f;
        blueColor.g = 0f;
        blueColor.b = blueValue;
        blueSpriteRenderer.color = blueColor;

        // Update texts with slider value
        rValueText.text = "" + red.value.ToString();
        gValueText.text = "" + green.value.ToString();
        bValueText.text = "" + blue.value.ToString();
    }
}
