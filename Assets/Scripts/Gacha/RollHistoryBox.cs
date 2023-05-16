using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollHistoryBox : MonoBehaviour
{
    public FishHistoryRecord record;

    public TMP_Text fishName;
    public TMP_Text fishDate;
    public TMP_Text fishColor;

    public SpriteRenderer fishSprite;
    public SpriteRenderer fishSilhouette;
    public SpriteRenderer gachaBoxSprite;

    // Update is called once per frame
    void Update()
    {
        fishName.text = record.fishName;
        fishDate.text = record.fishDate;
        fishColor.text = "#" + ColorUtility.ToHtmlStringRGB(record.fishColor);

        fishSprite.sprite = record.fishSprite;
        fishSilhouette.sprite = record.fishSilhouette;
        fishSilhouette.color = record.fishColor;

        gachaBoxSprite.sprite = record.gachaSprite;
    }
}
