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
    public bool accessLevel4 = true;
    public bool accessLevel5 = true;
    public bool accessLevel6 = true;
    public bool accessLevel7 = true;
    public bool accessLevel8 = true;
    public bool accessLevel9 = true;
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
        pearlCost = 4500;
    else if (currentLevel == 2)
        pearlCost = 9000;
    else if (currentLevel == 3)
        pearlCost = 15000;
    else if (currentLevel == 4)
        pearlCost = 21250;
    else if (currentLevel == 5)
        pearlCost = 32500;
    else if (currentLevel == 6)
        pearlCost = 45000;
    else if (currentLevel == 7)
        pearlCost = 70000;
    else if (currentLevel == 8)
        pearlCost = 125000;
    else if (currentLevel == 9)
        pearlCost = 250000;

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
            else if (currentLevel == 4)
            {
                purchaseLevel5();
                clickCount = 0; 
            }
            else if (currentLevel == 5)
            {
                purchaseLevel6();
                clickCount = 0; 
            }
            else if (currentLevel == 6)
            {
                purchaseLevel7();
                clickCount = 0; 
            }
            else if (currentLevel == 7)
            {
                purchaseLevel8();
                clickCount = 0; 
            }
            else if (currentLevel == 8)
            {
                purchaseLevel9();
                clickCount = 0; 
            }
            else if (currentLevel == 9)
            {
                purchaseMaxLevel();
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
        if (game.pearls >= 4500 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            game.activeFishMax = 10;
            accessLevel2 = false;
            expandLevelDescription.text = "Lv 2 Freshwater Tank\nCurrent: 10 max fish";
            expandUpgradeValue.text = "10 > 15 max fish";
            game.pearls -= 4500;
            pearlCost = 9000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel3()
    {
        if (game.pearls >= 9000 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            game.activeFishMax = 15;
            accessLevel3 = false;
            expandLevelDescription.text = "Lv 3 Freshwater Tank\nCurrent: 15 max fish";
            expandUpgradeValue.text = "15 > 20 max fish";
            game.pearls -= 9000;
            pearlCost = 15000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel4()
    {
        if (game.pearls >= 15000 && currentLevel == 3 && accessLevel4)
        {
            IncreaseLevel();
            game.activeFishMax = 20;
            accessLevel4 = false;
            expandLevelDescription.text = "Lv 4 Freshwater Tank\nCurrent: 20 max fish";
            expandUpgradeValue.text = "20 > 25 max fish";
            game.pearls -= 15000;
            pearlCost = 21250;
            return true;
        }
        return false;
    }

    public bool purchaseLevel5()
    {
        if (game.pearls >= 21250 && currentLevel == 4 && accessLevel5)
        {
            IncreaseLevel();
            game.activeFishMax = 25;
            accessLevel5 = false;
            expandLevelDescription.text = "Lv 5 Freshwater Tank\nCurrent: 25 max fish";
            expandUpgradeValue.text = "25 > 30 max fish";
            game.pearls -= 21250;
            pearlCost = 32500;
            return true;
        }
        return false;
    }

    public bool purchaseLevel6()
    {
        if (game.pearls >= 32500 && currentLevel == 5 && accessLevel6)
        {
            IncreaseLevel();
            game.activeFishMax = 30;
            accessLevel6 = false;
            expandLevelDescription.text = "Lv 6 Freshwater Tank\nCurrent: 30 max fish";
            expandUpgradeValue.text = "30 > 35 max fish";
            game.pearls -= 32500;
            pearlCost = 45000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel7()
    {
        if (game.pearls >= 45000 && currentLevel == 6 && accessLevel7)
        {
            IncreaseLevel();
            game.activeFishMax = 35;
            accessLevel7 = false;
            expandLevelDescription.text = "Lv 7 Freshwater Tank\nCurrent: 35 max fish";
            expandUpgradeValue.text = "35 > 40 max fish";
            game.pearls -= 45000;
            pearlCost = 70000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel8()
    {
        if (game.pearls >= 70000 && currentLevel == 7 && accessLevel8)
        {
            IncreaseLevel();
            game.activeFishMax = 40;
            accessLevel8 = false;
            expandLevelDescription.text = "Lv 8 Freshwater Tank\nCurrent: 40 max fish";
            expandUpgradeValue.text = "40 > 45 max fish";
            game.pearls -= 70000;
            pearlCost = 125000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel9()
    {
        if (game.pearls >= 125000 && currentLevel == 8 && accessLevel9)
        {
            IncreaseLevel();
            game.activeFishMax = 45;
            accessLevel9 = false;
            expandLevelDescription.text = "Lv 9 Freshwater Tank\nCurrent: 45 max fish";
            expandUpgradeValue.text = "45 > 50 max fish";
            game.pearls -= 125000;
            pearlCost = 250000;
            return true;
        }
        return false;
    }

   public bool purchaseMaxLevel()
    {
    if (game.pearls >= 250000 && currentLevel == 9 && accessMaxLevel)
    {
        IncreaseLevel();
        game.activeFishMax = 50;
        accessMaxLevel = false;
        expandLevelText.text = "Max";
        expandLevelDescription.text = "Lv Max Freshwater Tank\nCurrent: 50 max fish";
        expandUpgradeValue.text = "Max Level";
        game.pearls -= 250000;

        return true;
    }
    return false;
}
}
