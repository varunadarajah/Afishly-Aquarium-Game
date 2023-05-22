using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishView : MonoBehaviour
{
    public Fish fish;
    public FishViewManager fm;
    public FishActiveToggle activeToggle;

    public TMP_Text nameText;
    public TMP_Text dateText;
    public TMP_Text colorText;
    public SpriteRenderer fishSprite;
    public SpriteRenderer fishColorSprite;
    public SpriteRenderer colorBox;

    public Sprite turtleSprite;

    void Start()
    {
        fm = GameObject.Find("FishViewPage").GetComponent<FishViewManager>();        
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = fish.fishName;
        dateText.text = fish.dateObtained.ToString("MM/dd/yy");
        colorText.text = "#" + ColorUtility.ToHtmlStringRGB(fish.fishColor);

        fishSprite.sprite = fish.GetComponent<SpriteRenderer>().sprite;
        colorBox.color = fish.fishColor;

        fishColorSprite.sprite = fish.colorSprite.sprite;
        fishColorSprite.color = fish.fishColor;

        if (fish.fishBreed == "Turtle")
        {
            fishSprite.sprite = turtleSprite;
            fishSprite.gameObject.transform.localPosition = new Vector3(0f, -0.08f, 0f);
            fishSprite.gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);

            fishColorSprite.gameObject.transform.localPosition = new Vector3(-0.08999979f, 0.03880119f, -0.0002441406f);
            fishColorSprite.gameObject.transform.localScale = new Vector3(0.1092f, 0.1092f, 0.1092f);
        }
    }

    public void Sell()
    {
        if(fish.isActive)
        {
            activeToggle.toggleActive();
        }
        fm.SellFish(fish);
    }
}
