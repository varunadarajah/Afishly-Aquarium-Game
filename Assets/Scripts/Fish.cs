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

    public SpriteRenderer fishShadow;
    public float shadowStrengh = 0.43f; // 1f is full opacity, 0 is transparent

    public int rarity;
    public int sellPrice;

    public float speed;
    public bool isMovingRight = true;

    void Start()
    {
        speed = .2f;
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
        fishShadow.color = new Color(0f, 0f, 0f, shadowStrengh); // sets shadow strength

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        colorSprite.color = fishColor;

        Vector3 pos = transform.position;
        if (pos.x > 1)
        {
            isMovingRight = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background"; 
            colorSprite.sortingLayerName = "Background";
            transform.localScale = new Vector3(30f, 30f, 1f);

            fishShadow.gameObject.SetActive(true); // enable shadow gameobject
        }
        else if (pos.x < -1)
        {
            isMovingRight = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish"; 
            colorSprite.sortingLayerName = "Fish";
            transform.localScale = new Vector3(60f, 60f, 1f);

            fishShadow.gameObject.SetActive(false); // disable shadow gameobject
        }

        if (isMovingRight)
        {
            pos.x += speed * Time.deltaTime;
        }
        else
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
