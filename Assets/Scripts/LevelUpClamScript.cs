using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpClamScript : MonoBehaviour
{
    public Game game;
    public int currentLevel = 1;
    public Clam clamUpgrade;
    public TMP_Text clamLevelText;
    public TMP_Text clamLevelDescription;
    public TMP_Text clamUpgradeValue;
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
    public int clickCount;

    public UnlockMusselScript unlockMussel;
    public UnlockOysterScript unlockOyster;

    // Start is called before the first frame update
    void Start()
    {
        unlockMussel = GameObject.FindObjectOfType<UnlockMusselScript>();
        unlockOyster = GameObject.FindObjectOfType<UnlockOysterScript>();
    }

    // Update is called once per frame
    void Update()
    {
    int musselCount = unlockMussel.clickCount;
    int oysterCount = unlockOyster.clickCount;
    if (currentLevel == 1)
        pearlCost = 250;
    else if (currentLevel == 2)
        pearlCost = 1000;
    else if (currentLevel == 3)
        pearlCost = 2250;
    else if (currentLevel == 4)
        pearlCost = 5000;
    else if (currentLevel == 5)
        pearlCost = 10500;
    else if (currentLevel == 6)
        pearlCost = 30000;
    else if (currentLevel == 7)
        pearlCost = 75000;
    else if (currentLevel == 8)
        pearlCost = 140000;
    else if (currentLevel == 9)
        pearlCost = 250000;

    button.interactable = game.pearls >= pearlCost;
    GrayLayer.SetActive(!button.interactable);

    if (clickCount == 0)
    {
        if (accessMaxLevel)
        {
            clamLevelText.text = $"Level Up\n{pearlCost} {spriteAsset}";
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
            clamLevelText.text = "Confirm";
            unlockMussel.clickCount = 0;
            unlockOyster.clickCount = 0;
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
        if (game.pearls >= 250 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap = 2;
            accessLevel2 = false;
            clamLevelDescription.text = "Lv 2 Regular Clam\n2 " + spriteAsset + "per tap";
            clamUpgradeValue.text = "2 > 3 " + spriteAsset + "per tap";
            game.pearls -= 250;
            pearlCost = 1000;
            return true;
        }
        return false;
    }

    public bool purchaseLevel3()
    {
        if (game.pearls >= 1000 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap = 3;
            accessLevel3 = false;
            clamLevelDescription.text = "Lv 3 Regular Clam\n3 " + spriteAsset + "per tap";
            clamUpgradeValue.text = "3 > 5 " + spriteAsset + "per tap";
            game.pearls -= 1000;
            pearlCost = 2250;
            return true;
        }
        return false;
    }

   public bool purchaseLevel4()
    {
    if (game.pearls >= 2250 && currentLevel == 3 && accessLevel4)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap = 5;
        accessLevel4 = false;
        clamLevelDescription.text = "Lv 4 Regular Clam\n5 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "5 > 7 " + spriteAsset + "per tap";
        game.pearls -= 2250;
        pearlCost = 5000;
        return true;
    }
    return false;
    }

    public bool purchaseLevel5()
    {
    if (game.pearls >= 5000 && currentLevel == 4 && accessLevel5)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap = 7;
        accessLevel5 = false;
        clamLevelDescription.text = "Lv 5 Regular Clam\n7 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "7 > 10 " + spriteAsset + "per tap";
        game.pearls -= 5000;
        pearlCost = 10500;
        return true;
    }
    return false;
    }

    public bool purchaseLevel6()
    {
    if (game.pearls >= 10500 && currentLevel == 5 && accessLevel6)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap = 10;
        accessLevel6 = false;
        clamLevelDescription.text = "Lv 6 Regular Clam\n10 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "10 > 15 " + spriteAsset + "per tap";
        game.pearls -= 10500;
        return true;
    }
    return false;
    }

    public bool purchaseLevel7()
    {
    if (game.pearls >= 30000 && currentLevel == 6 && accessLevel7)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap = 15;
        accessLevel7 = false;
        clamLevelDescription.text = "Lv 7 Regular Clam\n15 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "15 > 20 " + spriteAsset + "per tap";
        game.pearls -= 30000;
        pearlCost = 75000;
        return true;
    }
    return false;
    }

    public bool purchaseLevel8()
    {
    if (game.pearls >= 75000 && currentLevel == 7 && accessLevel8)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap = 20;
        accessLevel8 = false;
        clamLevelDescription.text = "Lv 8 Regular Clam\n20 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "20 > 25 " + spriteAsset + "per tap";
        game.pearls -= 75000;
        pearlCost = 140000;
        return true;
    }
    return false;
    }

    public bool purchaseLevel9()
    {
    if (game.pearls >= 140000 && currentLevel == 8 && accessLevel9)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap = 25;
        accessLevel9 = false;
        clamLevelDescription.text = "Lv 9 Regular Clam\n25 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "25 > 40 " + spriteAsset + "per tap";
        game.pearls -= 140000;
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
        clamUpgrade.pearlPerTap = 40;
        accessMaxLevel = false;
        clamLevelText.text = "Max";
        clamLevelDescription.text = "Lv Max Regular Clam\n40 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "";
        game.pearls -= 250000;
        return true;
    }
    return false;
    }
}