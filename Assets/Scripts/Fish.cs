using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Fish : MonoBehaviour
{
    public string fishBreed;
    public string fishName;
    public string dateObtained;
    public Color fishColor = Color.clear;
    public bool isActive = false;

    public SpriteRenderer colorSprite;

    public SpriteRenderer fishShadow;
    public float shadowStrengh = 0.83f; // 1f is full opacity, 0 is transparent

    public float fishSize = 60f;

    public int rarity;
    public int sellPrice;

    public float speed;
    public bool isMovingRight = true;

    // Add new variables for the fish's vertical movement
    public float minY;
    public float verticalSpeed = 0.05f;
    private float direction1 = 1f;

    public RandomScript random;
    public LeftToRightScript LTR;
    public RightToLeftScript RTL;


    public void Start()
    {
        GameObject Random = GameObject.Find("RandomButton");
        random = Random.GetComponent<RandomScript>();
        GameObject LeftToRight = GameObject.Find("LeftToRightButton");
        LTR = LeftToRight.GetComponent<LeftToRightScript>();
        GameObject RightToLeft = GameObject.Find("RightToLeftButton");
        RTL = RightToLeft.GetComponent<RightToLeftScript>();

        setDate();
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
                    speed = .1f;
                    pos.y = randomYBack;
                    transform.localScale = new Vector3(15f, 15, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                    colorSprite.sortingLayerName = "Background";
                    fishShadow.gameObject.SetActive(true); // enable shadow gameobject
                }
                else if (direction == 0)
                {
                    speed = .2f;
                    pos.y = randomYFront;
                    transform.localScale = new Vector3(fishSize, fishSize, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                    colorSprite.sortingLayerName = "Fish";
                    fishShadow.gameObject.SetActive(false); // disable shadow gameobject
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
                    speed = .1f;
                    pos.y = randomYBack;
                    transform.localScale = new Vector3(15f, 15, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                    colorSprite.sortingLayerName = "Background";
                    fishShadow.gameObject.SetActive(true); // enable shadow gameobject
                }
                else if (direction == 0)
                {
                    speed = .2f;
                    pos.y = randomYFront;
                    transform.localScale = new Vector3(fishSize, fishSize, 1f);
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                    gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                    colorSprite.sortingLayerName = "Fish";
                    fishShadow.gameObject.SetActive(false); // disable shadow gameobject
                }
            }
        }
        if (LTR.LeftToRight == true)
        {
            if (pos.x > 1)
            {
                isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                speed = .1f;
                pos.y = randomYBack;
                transform.localScale = new Vector3(15f, 15, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                colorSprite.sortingLayerName = "Background";
                fishShadow.gameObject.SetActive(true); // enable shadow gameobject
            }
            else if (pos.x < -1)
            {
                isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                speed = .2f;
                pos.y = randomYFront;
                transform.localScale = new Vector3(fishSize, fishSize, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                colorSprite.sortingLayerName = "Fish";
                fishShadow.gameObject.SetActive(false); // disable shadow gameobject
            }
        }
        if (RTL.RightToLeft == true)
        {
            if (pos.x > 1)
            {
                isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                speed = .2f;
                pos.y = randomYFront;
                transform.localScale = new Vector3(fishSize, fishSize, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Fish";
                colorSprite.sortingLayerName = "Fish";
                fishShadow.gameObject.SetActive(false); // disable shadow gameobject
            }
            else if (pos.x < -1)
            {
                isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                speed = .1f;
                pos.y = randomYBack;
                transform.localScale = new Vector3(15f, 15, 1f);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                gameObject.GetComponent<SortingGroup>().sortingLayerName = "Background";
                colorSprite.sortingLayerName = "Background";
                fishShadow.gameObject.SetActive(true); // enable shadow gameobject

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
        dateObtained = System.DateTime.UtcNow.ToLocalTime().ToString("MM/dd/yy");
    }

    public void setFishColor()
    {
        if (fishColor == Color.clear)
        {
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
        }

        colorSprite.color = fishColor;

        fishShadow.color = new Color(0f, 0f, 0f, shadowStrengh); // sets shadow strength

        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Fish";
        colorSprite.sortingLayerName = "Fish";
    }

    public void setInitialSpeed()
    {
        speed = .2f;
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
