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
        pearlCost = 100;
    else if (currentLevel == 2)
        pearlCost = 1000;
    else if (currentLevel == 3)
        pearlCost = 2000;
    else if (currentLevel == 4)
        pearlCost = 5000;

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
        if (game.pearls >= 100 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 4;
            accessLevel2 = false;
            clamLevelDescription.text = "Lv 2 Regular Clam\n5 " + spriteAsset + "per tap";
            clamUpgradeValue.text = "5 > 10 " + spriteAsset + "per tap";
            game.pearls -= 100;
            return true;
        }
        return false;
    }

    public bool purchaseLevel3()
    {
        if (game.pearls >= 500 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 5;
            accessLevel3 = false;
            clamLevelDescription.text = "Lv 3 Regular Clam\n10 " + spriteAsset + "per tap";
            clamUpgradeValue.text = "10 > 20 " + spriteAsset + "per tap";
            game.pearls -= 500;
            //close menu
            return true;
        }
        return false;
    }

   public bool purchaseLevel4()
    {
    if (game.pearls >= 2000 && currentLevel == 3 && accessLevel4)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap += 10;
        accessLevel4 = false;
        clamLevelDescription.text = "Lv 4 Regular Clam\n20 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "20 > 50 " + spriteAsset + "per tap";
        game.pearls -= 2000;

        return true;
    }
    return false;
}

public bool purchaseMaxLevel()
    {
    if (game.pearls >= 5000 && currentLevel == 4 && accessMaxLevel)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap += 30;
        accessMaxLevel = false;
        clamLevelText.text = "Max";
        clamLevelDescription.text = "Lv Max Regular Clam\n50 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "";
        game.pearls -= 5000;
        return true;
    }
    return false;
}
}