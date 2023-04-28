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
    public float shadowStrengh = 0.63f; // 1f is full opacity, 0 is transparent

    public int rarity;
    public int sellPrice;

    public float speed;
    public bool isMovingRight = true;

    // Add new variables for the fish's vertical movement
    public float minY;
    public float verticalSpeed = 0.1f;
    private float direction = 1f;
    

    void Start()
    {
        float randomX = (Random.Range(0, 2) * 2 - 1) * 1f; // either -1 or 1
        float randomY = Random.Range(-.6f, 1f);
        transform.position = new Vector3(randomX, randomY, 0f);

        //if the fish starts out on the left side of the screen, change its orientation
        if(randomX == -1) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

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
        
        //change the fishes orientation when it hits the right edge of the screen
        if (pos.x > 1)
        {
            isMovingRight = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            int randomPosition = Random.Range(0, 2);
            //randomizes whether the fish will come back in the background or front of screen
            if (randomPosition == 1) {
                transform.localScale = new Vector3(15f, 15, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                colorSprite.sortingLayerName = "Background";
                fishShadow.gameObject.SetActive(true); // enable shadow gameobject
            }   
            else if (randomPosition == 0) 
            {
                transform.localScale = new Vector3(60f, 60f, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                colorSprite.sortingLayerName = "Fish";
                fishShadow.gameObject.SetActive(false); // disable shadow gameobject
            }
        }
        //change the fishes orientation if it hits the left edge of the screen
        else if (pos.x < -1)
        {
            isMovingRight = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            int randomPosition = Random.Range(0, 2);
            if (randomPosition == 1) {
                transform.localScale = new Vector3(15f, 15, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                colorSprite.sortingLayerName = "Background";
                fishShadow.gameObject.SetActive(true); // enable shadow gameobject
            } 
            else if (randomPosition == 0) 
            {
                transform.localScale = new Vector3(60f, 60f, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                colorSprite.sortingLayerName = "Fish";
                fishShadow.gameObject.SetActive(false); // disable shadow gameobject
            }
        }

        if (isMovingRight)
        {
            pos.x += speed * Time.deltaTime;
        }
        else
        {
            pos.x -= speed * Time.deltaTime;
        }

         pos.y += verticalSpeed * direction * Time.deltaTime;

    //keeps the fish inside of the screen
    if (pos.y > 1 || pos.y < -.6)
    {
        direction *= -1f;
    }

    // Randomly change the vertical direction if the fish hits the left or right edge of the screen
    if (pos.x > 1 || pos.x < -1)
    {
        if (Random.value > 0.5f)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }
    }
        transform.position = pos;
    }
}
