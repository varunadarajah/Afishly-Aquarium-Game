using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public string fishBreed;
    public string fishName;
    public string dateObtained;
    public Color fishColor;
    public bool isActive = false;

    public SpriteRenderer colorSprite;

    public int rarity;
    public int sellPrice;

    void Start()
    {
        dateObtained = System.DateTime.UtcNow.ToLocalTime().ToString("MM/dd/yy");

        // get the hex string from the HSBSliderScript
        HSBSliderScript hsbSliderScript = FindObjectOfType<HSBSliderScript>();
        string hexColor = hsbSliderScript.hexText.text;

        // check if hexColor is a valid hex string
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            fishColor = newColor;
        }
        else
        {
            fishColor = Color.white; // set to default color
        }

        colorSprite = GetComponentsInChildren<SpriteRenderer>()[1]; // gets silloute sprite
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        colorSprite.color = fishColor;
    }
}
