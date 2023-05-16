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
    void Update()
    {
        fishName.text = fish.fishName;
        oddsPercent.text = fish.rarity + "%";
        fishSprite.sprite = fish.gameObject.GetComponent<SpriteRenderer>().sprite;
        fishSilhouette.sprite = fish.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].sprite;
    }
}
