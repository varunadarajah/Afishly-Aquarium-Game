using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OddsPageManager : MonoBehaviour
{
    public GachaManager gm;

    public SpriteRenderer gachaSprite;
    public TMP_Text gachaName;

    public List<GameObject> oddsBoxes;
    public GameObject FishOddsBox; // prefab
    public GameObject oddsBoxesObj; // gameobject to where boxes are instantiated

    // Start is called before the first frame update
    void Start()
    {
        setBox();
    }

    public void ScrollLeft()
    {
        gm.ScrollLeft();
        setBox();
    }

    public void ScrollRight()
    {
        gm.ScrollRight();
        setBox();
    }

    public void setBox()
    {
        Reset();
        gachaSprite.sprite = gm.selectedBox.gameObject.GetComponent<SpriteRenderer>().sprite;
        gachaName.text = gm.selectedBox.gachaName;
        addFishOddsBoxes();
    }

    public void addFishOddsBoxes()
    {
        foreach(Fish f in gm.selectedBox.possibleFishes)
        {
            GameObject newBox = Instantiate(FishOddsBox, oddsBoxesObj.transform);
            newBox.GetComponent<FishOddsBox>().fish = f;
            oddsBoxes.Add(newBox);
        }
    }

    void Reset()
    {
        foreach (GameObject box in oddsBoxes)
        {
            Destroy(box);
        }
        oddsBoxes.Clear();
    }
}
