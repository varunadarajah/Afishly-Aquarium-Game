using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public string fishBreed;
    public string fishName;
    public System.DateTime dateObtained;
    public Color fishColor = Color.clear;
    public bool isActive = false;

    public SpriteRenderer colorSprite;

    public SpriteRenderer fishShadow;
    public float shadowStrengh = 0.83f; // 1f is full opacity, 0 is transparent

    public float fishSize = 60f;
    public float fishBackgroundSize = 15f;

    public int rarity;
    public int sellPrice;

    float currentSpeed = 0.2f;
    public float speed = 0.2f;
    float backgroundSpeed = 0.1f;
    public bool isMovingRight = true;

    // Add new variables for the fish's vertical movement
    public float minY;
    public float verticalSpeed = 0.05f;
    private float direction1 = 1f;

    public RandomScript random;
    public LeftToRightScript LTR;
    public RightToLeftScript RTL;

    public string copiedText = "";

    public void Start()
    {
        GameObject Random = GameObject.Find("RandomButton");
        random = Random.GetComponent<RandomScript>();
        GameObject LeftToRight = GameObject.Find("LeftToRightButton");
        LTR = LeftToRight.GetComponent<LeftToRightScript>();
        GameObject RightToLeft = GameObject.Find("RightToLeftButton");
        RTL = RightToLeft.GetComponent<RightToLeftScript>();        
                
        setFishColor();
        setInitialSpeed();
        setFishPos();

        if (!isActive)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        float randomYFront = Random.Range(-.9f, .9f);
        float randomYBack = Random.Range(-.6f, .9f);
        colorSprite.color = fishColor;

        Vector3 pos = transform.position;

        if(fishBreed == "Turtle")
        {
            if(isActive)
            {
                gameObject.GetComponent<Animator>().enabled = true;
                fishShadow.gameObject.GetComponent<Animator>().enabled = true;
            } else
            {
                gameObject.GetComponent<Animator>().enabled = false;
                fishShadow.gameObject.GetComponent<Animator>().enabled = false;
            }
        }

        if (random == true)
        {
            //change the fishes orientation when it hits the right edge of the screen
            if (pos.x > 1)
            {
                isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                int direction = Random.Range(0, 2);
                //randomizes whether the fish will come back in the background or front of screen
                if (direction == 1)
                {
                    currentSpeed = backgroundSpeed;
                    pos.y = randomYBack;
                    transform.localScale = new Vector3(fishBackgroundSize, fishBackgroundSize, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                    colorSprite.sortingLayerName = "Background";
                }
                else if (direction == 0)
                {
                    currentSpeed = speed;
                    pos.y = randomYFront;
                    transform.localScale = new Vector3(fishSize, fishSize, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                    colorSprite.sortingLayerName = "Fish";
                }
            }
            //change the fishes orientation if it hits the left edge of the screen
            else if (pos.x < -1)
            {
                isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                int direction = Random.Range(0, 2);
                if (direction == 1)
                {
                    currentSpeed = backgroundSpeed;
                    pos.y = randomYBack;
                    transform.localScale = new Vector3(fishBackgroundSize, fishBackgroundSize, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                    colorSprite.sortingLayerName = "Background";
                }
                else if (direction == 0)
                {
                    currentSpeed = speed;
                    pos.y = randomYFront;
                    transform.localScale = new Vector3(fishSize, fishSize, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                    colorSprite.sortingLayerName = "Fish";
                }
            }
        }
        if (LTR.LeftToRight == true)
        {
            if (pos.x > 1)
            {
                isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                currentSpeed = backgroundSpeed;
                pos.y = randomYBack;
                transform.localScale = new Vector3(fishBackgroundSize, fishBackgroundSize, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                colorSprite.sortingLayerName = "Background";
            }
            else if (pos.x < -1)
            {
                isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                currentSpeed = speed;
                pos.y = randomYFront;
                transform.localScale = new Vector3(fishSize, fishSize, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                colorSprite.sortingLayerName = "Fish";
            }
        }
        if (RTL.RightToLeft == true)
        {
            if (pos.x > 1)
            {
                isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                currentSpeed = speed;
                pos.y = randomYFront;
                transform.localScale = new Vector3(fishSize, fishSize, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                colorSprite.sortingLayerName = "Fish";
            }
            else if (pos.x < -1)
            {
                isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                currentSpeed = backgroundSpeed;
                pos.y = randomYBack;
                transform.localScale = new Vector3(fishBackgroundSize, fishBackgroundSize, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                colorSprite.sortingLayerName = "Background";

            }
        }

        if (isMovingRight)
        {
            pos.x += currentSpeed * Time.deltaTime;
        }
        else
        {
            pos.x -= currentSpeed * Time.deltaTime;
        }


        pos.y += verticalSpeed * direction1 * Time.deltaTime;

        if (gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Background")
        {
            if (pos.y > 1 || pos.y < -0.55f)
            {
                direction1 *= -1f;
            }
        }

        if (gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Fish")
        {
            if (pos.y > 1 || pos.y < -1)
            {
                direction1 *= -1f;
            }
        }

        //  if (pos.y > 1 || pos.y < -1)
        // {
        //     direction1 *= -1f;
        // }

        // Randomly change the vertical direction if the fish hits the left or right edge of the screen
        if (pos.x > .9 || pos.x < -.9)
        {
            if (Random.value > 0.45f)
            {
                direction1 = 1f;
            }
            else
            {
                direction1 = -1f;
            }
        }
        transform.position = pos;
    }

    public void setDate()
    {
        dateObtained = System.DateTime.UtcNow.ToLocalTime();
    }

    public void setFishColor()
    {
          if (fishColor == Color.clear)
        {
        InputField hexInput = GameObject.Find("HexInput")?.GetComponent<InputField>();
        // HSBSliderScript hsbSliderScript = FindObjectOfType<HSBSliderScript>();
        string hexColor = hexInput.text;
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
        }

        colorSprite.color = fishColor;

        fishShadow.color = new Color(0f, 0f, 0f, shadowStrengh); // sets shadow strength

        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
        colorSprite.sortingLayerName = "Fish";
    }

    public void setInitialSpeed()
    {
        currentSpeed = speed;
        backgroundSpeed = speed / 2;
    }

    public void setFishPos()
    {
        float randomX = (Random.Range(0, 2) * 2 - 1) * 1f; // either -1 or 1
        float randomY = Random.Range(-1f, 1f);
        transform.position = new Vector3(randomX, randomY, 0f);

        //if the fish starts out on the left side of the screen, change its orientation
        if (randomX == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
