using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishOddsBox : MonoBehaviour
{
    public Fish fish;

    public TMP_Text fishName;
    public TMP_Text oddsPercent;
    public SpriteRenderer fishSprite;
    public SpriteRenderer fishSilhouette;

    // Start is called before the first frame update
    void Start()
    {
        fishName.text = fish.fishName;
        oddsPercent.text = fish.rarity + "%";
        fishSprite.sprite = fish.gameObject.GetComponent<SpriteRenderer>().sprite;
        fishSilhouette.sprite = fish.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].sprite;

        if(fish.fishBreed == "Turtle")
        {
            fishSprite.gameObject.transform.localPosition = new Vector3(1.47f, -0.09f, -0.5519976f);
            fishSprite.gameObject.transform.localScale = new Vector3(0.07f, 0.12383f, 0f);

            fishSilhouette.gameObject.transform.localPosition = new Vector3(1.5087f, 1.9671f, 0f);
            fishSilhouette.gameObject.transform.localScale = new Vector3(1.827819f, 1.825201f, 1f);
        }
    }
}
