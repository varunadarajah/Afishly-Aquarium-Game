using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockMusselScript : MonoBehaviour
{
    public Game game;
    public int currentLevel = 0; // Add a level variable to keep track of the object's level
    public int musselPearls;
    public TMP_Text musselLevelText;
    public TMP_Text musselLevelDescription;
    public TMP_Text musselUpgradeValue; 
    string spriteAsset = "<sprite name=\"Pearl\">";
    public GameObject objectToToggle; // Reference to the object toggle
    bool accessLevel1 = true;
    bool accessLevel2 = true;
    bool accessLevel3 = true;
    bool accessLevel4 = true;
    bool accessLevel5 = true;
    bool accessLevel6 = true;
    bool accessLevel7 = true;
    bool accessLevel8 = true;
    bool accessLevel9 = true;
    bool accessMaxLevel = true;

    public GameObject GrayLayer;

    public Button button;
    public int pearlCost;
    public int clickCount;

    public LevelUpClamScript levelUpClam;
    public UnlockOysterScript unlockOyster;

    // Start is called before the first frame update
    void Start()
    {
        levelUpClam = GameObject.FindObjectOfType<LevelUpClamScript>();
        unlockOyster = GameObject.FindObjectOfType<UnlockOysterScript>();
    }

     // Update is called once per frame
    void Update()
    {
    int clamCount = levelUpClam.clickCount;
    int oysterCount = unlockOyster.clickCount;
    if (currentLevel == 0) 
        pearlCost = 5000;
    else if (currentLevel == 1)
        pearlCost = 5000;
    else if (currentLevel == 2)
        pearlCost = 10000;
    else if (currentLevel == 3)
        pearlCost = 20000;
    else if (currentLevel == 4)
        pearlCost = 25000;
    else if (currentLevel == 5)
        pearlCost = 50000;
    else if (currentLevel == 6)
        pearlCost = 125000;
    else if (currentLevel == 7)
        pearlCost = 250000;
    else if (currentLevel == 8)
        pearlCost = 375000;
    else if (currentLevel == 9)
        pearlCost = 500000;

    button.interactable = game.pearls >= pearlCost;
    GrayLayer.SetActive(!button.interactable);

    if (clickCount == 0)
    {
       if (accessMaxLevel)
        {
            if (currentLevel == 0) {
                musselLevelText.text = $"Unlock\n{pearlCost} {spriteAsset}";
            } else {
            musselLevelText.text = $"Level Up\n{pearlCost} {spriteAsset}";
            }
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
            musselLevelText.text = "Confirm";
            levelUpClam.clickCount = 0;
            unlockOyster.clickCount = 0;
        }
        else if (clickCount == 2)
        {
            if (currentLevel == 0) {
                unlockMussel();
                clickCount = 0;
            }
            else if (currentLevel == 1)
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

    void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    bool unlockMussel()
    {
        if(game.pearls >= 5000 && currentLevel == 0 && accessLevel1)
        {
            ToggleObject();
            IncreaseLevel();
            accessLevel1 = false;
            musselLevelDescription.text = "Lv 1 Mussel\n1 " + spriteAsset + "per second";
            musselUpgradeValue.text = "1 > 2 " + spriteAsset + "per second";
            game.pearls -= 5000;
            pearlCost = 5000;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel2()
    {
        if(game.pearls >= 5000 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            accessLevel2 = false;
            musselLevelDescription.text = "Lv 2 Mussel\n2 " + spriteAsset + "per second";
            musselUpgradeValue.text = "2 > 3 " + spriteAsset + "per second";
            game.pearls -= 5000;
            pearlCost = 10000;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel3()
    {
        if(game.pearls >= 10000 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            accessLevel3 = false;
            musselLevelDescription.text = "Lv 3 Mussel\n3 " + spriteAsset + "per second";
            musselUpgradeValue.text = "3 > 4 " + spriteAsset + "per second";
            game.pearls -= 10000;
            pearlCost = 20000;
            return true;
        }
        return false;
    }

    bool purchaseLevel4()
    {
        if(game.pearls >= 20000 && currentLevel == 3 && accessLevel4)
        {
            IncreaseLevel();
            accessLevel4 = false;
            musselLevelDescription.text = "Lv 4 Mussel\n4 " + spriteAsset + "per second";
            musselUpgradeValue.text = "4 > 5 " + spriteAsset + "per second";
            game.pearls -= 20000;
            pearlCost = 25000;
            return true;
        }
        return false;
    }

    bool purchaseLevel5()
    {
        if(game.pearls >= 25000 && currentLevel == 4 && accessLevel5)
        {
            IncreaseLevel();
            accessLevel5 = false;
            musselLevelDescription.text = "Lv 5 Mussel\n5 " + spriteAsset + "per second";
            musselUpgradeValue.text = "5 > 7 " + spriteAsset + "per second";
            game.pearls -= 25000;
            pearlCost = 50000;
            return true;
        }
        return false;
    }

    bool purchaseLevel6()
    {
        if(game.pearls >= 50000 && currentLevel == 5 && accessLevel6)
        {
            IncreaseLevel();
            accessLevel6 = false;
            musselLevelDescription.text = "Lv 6 Mussel\n7 " + spriteAsset + "per second";
            musselUpgradeValue.text = "7 > 9 " + spriteAsset + "per second";
            game.pearls -= 50000;
            pearlCost = 125000;
            return true;
        }
        return false;
    }

    bool purchaseLevel7()
    {
        if(game.pearls >= 125000 && currentLevel == 6 && accessLevel7)
        {
            IncreaseLevel();
            accessLevel7 = false;
            musselLevelDescription.text = "Lv 7 Mussel\n9 " + spriteAsset + "per second";
            musselUpgradeValue.text = "9 > 12 " + spriteAsset + "per second";
            game.pearls -= 125000;
            pearlCost = 250000;
            return true;
        }
        return false;
    }

    bool purchaseLevel8()
    {
        if(game.pearls >= 250000 && currentLevel == 7 && accessLevel8)
        {
            IncreaseLevel();
            accessLevel8 = false;
            musselLevelDescription.text = "Lv 8 Mussel\n12 " + spriteAsset + "per second";
            musselUpgradeValue.text = "12 > 25 " + spriteAsset + "per second";
            game.pearls -= 250000;
            pearlCost = 375000;
            return true;
        }
        return false;
    }

    bool purchaseLevel9()
    {
        if(game.pearls >= 375000 && currentLevel == 8 && accessLevel9)
        {
            IncreaseLevel();
            accessLevel9 = false;
            musselLevelDescription.text = "Lv 9 Mussel\n25 " + spriteAsset + "per second";
            musselUpgradeValue.text = "25 > 50 " + spriteAsset + "per second";
            game.pearls -= 375000;
            pearlCost = 500000;
            return true;
        }
        return false;
    }

     bool purchaseMaxLevel()
    {
        if(game.pearls >= 500000 && currentLevel == 9 && accessMaxLevel)
        {
            IncreaseLevel();
            accessMaxLevel = false;
            musselLevelText.text = "Max";
            musselLevelDescription.text = "Lv Max Mussel\n50 " + spriteAsset + "per second";
            musselUpgradeValue.text = "";
            game.pearls -= 500000;
            return true;
        }
        return false;
    }

    void ToggleObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf); // Toggle the active state of the other object
        }
    }
}