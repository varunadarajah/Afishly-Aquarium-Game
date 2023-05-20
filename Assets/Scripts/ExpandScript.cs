using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpandScript : MonoBehaviour
{
    public Game game;
    public int currentLevel = 1; // Add a level variable to keep track of the object's level
    public TMP_Text expandLevelText;
    public TMP_Text expandLevelDescription;
    public TMP_Text expandUpgradeValue;
    string spriteAsset = "<sprite name=\"Pearl\">";
    public bool accessLevel2 = true;
    public bool accessLevel3 = true;
    public bool accessMaxLevel = true;

    public GameObject GrayLayer;

    public Button button;
    public int pearlCost;
    private int clickCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    if (currentLevel == 1)
        pearlCost = 10000;
    else if (currentLevel == 2)
        pearlCost = 20000;
    else if (currentLevel == 3)
        pearlCost = 30000;

    button.interactable = game.pearls >= pearlCost;
    GrayLayer.SetActive(!button.interactable);

    if (clickCount == 0)
    {
        if (accessMaxLevel)
        {
            expandLevelText.text = $"Level Up\n{pearlCost} {spriteAsset}";
        }
        else
        {
            button.interactable = false;
            GrayLayer.SetActive(true);
        }
    }
    }

    private void OnDisable()
    {
        clickCount = 0;
    }

    public void OnMouseDown()
    {
        if (button.interactable == true)
        {
            clickCount++;
        }

        if (clickCount == 1)
        {
            expandLevelText.text = "Confirm";
        }
        else if (clickCount == 2)
        {
            if (currentLevel == 1)
            {
                purchaseLevel2();
                clickCount = 0; 
            }
            else if (currentLevel == 2)
            {
                purchaseLevel3();
                clickCount = 0; 
            }
            else if (currentLevel == 3)
            {
                purchaseLevel4();
                clickCount = 0; 
            }
        }
    }

    public void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    public bool purchaseLevel2()
    {
        if (game.pearls >= 10000 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            game.activeFishMax = 15;
            accessLevel2 = false;
            expandLevelDescription.text = "Lv 2 Freshwater Tank\nCurrent: 15 max fish";
            expandUpgradeValue.text = "15 > 20 max fish";
            game.pearls -= 10000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel3()
    {
        if (game.pearls >= 20000 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            game.activeFishMax = 20;
            accessLevel3 = false;
            expandLevelDescription.text = "Lv 3 Freshwater Tank\nCurrent: 20 max fish";
            expandUpgradeValue.text = "20 > 25 max fish";
            game.pearls -= 20000;
            //close menu
            return true;
        }
        return false;
    }

   public bool purchaseLevel4()
    {
    if (game.pearls >= 30000 && currentLevel == 3 && accessMaxLevel)
    {
        IncreaseLevel();
        game.activeFishMax = 25;
        accessMaxLevel = false;
        expandLevelText.text = "Max";
        expandLevelDescription.text = "Lv Max Freshwater Tank\nCurrent: 25 max fish";
        expandUpgradeValue.text = "Max Level";
        game.pearls -= 30000;

        return true;
    }
    return false;
}
}
