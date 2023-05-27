using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishHistoryBox : MonoBehaviour
{
    public Game game;

    public FishHistoryRecord record;

    public TMP_Text fishBreed;
    public TMP_Text fishDate;
    public TMP_Text fishColor;

    public SpriteRenderer fishSprite;
    public SpriteRenderer fishSilhouette;
    public SpriteRenderer gachaBoxSprite;

    public Sprite vanillaBoxSprite;
    public Sprite turtleBoxSprite;

    private void Start()
    {
        game = GameObject.Find("GameEngine").GetComponent<Game>();

        fishBreed.text = record.fishBreed;
        fishDate.text = record.fishDate;
        fishColor.text = "#" + ColorUtility.ToHtmlStringRGB(record.fishColor);

        fishSilhouette.color = record.fishColor;

        foreach (Fish prefab in game.allFishPrefabs) // find matching prefab to instantiate
        {
            if (record.fishBreed == prefab.fishBreed)
            {
                fishSprite.sprite = prefab.GetComponent<SpriteRenderer>().sprite;
                fishSilhouette.sprite = prefab.colorSprite.sprite;
            }
        }

        if(record.fishBreed == "Turtle")
        {
            fishSprite.gameObject.transform.localPosition = new Vector3(1.422f, -0.116f, -0.5519976f);
            fishSprite.gameObject.transform.localScale = new Vector3(0.085f, 0.1144843f, 0.223494f);

            fishSilhouette.gameObject.transform.localPosition = new Vector3(1.55f, 1.95f, -0.0002441406f);
            fishSilhouette.gameObject.transform.localScale = new Vector3(1.81f, 1.81f, 1.81f);
        }

        if(record.gacha == "Vanilla Box")
        {
            gachaBoxSprite.sprite = vanillaBoxSprite;
        }
        else if(record.gacha == "Turtle Box")
        {
            gachaBoxSprite.sprite = turtleBoxSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
