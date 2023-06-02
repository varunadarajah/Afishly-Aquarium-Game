using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockOysterScript : MonoBehaviour
{
    public Game game;
    public int currentLevel = 0; // Add a level variable to keep track of the object's level
    public TMP_Text oysterLevelText;
    public TMP_Text oysterLevelDescription;
    public TMP_Text oysterUpgradeValue; 
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
    public UnlockMusselScript unlockMussel;

    //  buy sound effect
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        levelUpClam = GameObject.FindObjectOfType<LevelUpClamScript>();

        unlockMussel = GameObject.FindObjectOfType<UnlockMusselScript>();
    }

    // Update is called once per frame
    void Update()
    {
        int clamCount = levelUpClam.clickCount;
        int musselCount = unlockMussel.clickCount;
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
                oysterLevelText.text = $"Unlock\n{pearlCost} {spriteAsset}";
            } else {
                oysterLevelText.text = $"Level Up\n{pearlCost} {spriteAsset}";
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
            oysterLevelText.text = "Confirm";
            levelUpClam.clickCount = 0;
            unlockMussel.clickCount = 0;
        }
        else if (clickCount == 2)
        {
            if (currentLevel == 0) {
                unlockOyster();
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

        if (game.gameLoaded)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    bool unlockOyster()
    {
        if(game.pearls >= 5000 && currentLevel == 0 && accessLevel1)
        {
            ToggleObject();
            IncreaseLevel();
            accessLevel1 = false;
            oysterLevelDescription.text = "Lv 1 Oyster\n1500 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "1500 > 3000 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 2 Oyster\n3000 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "3000 > 4500 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 3 Oyster\n4500 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "4500 > 6000 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 4 Oyster\n6000" + spriteAsset + "per tap";
            oysterUpgradeValue.text = "6000 > 7500 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 5 Oyster\n7500 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "7500 > 10500 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 6 Oyster\n10500 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "10500 > 14000 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 7 Oyster\n14000 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "14000 > 18000 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 8 Oyster\n18000 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "18000 > 26000 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelDescription.text = "Lv 9 Oyster\n26000 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "26000 > 36000 " + spriteAsset + "per bunch\n20 minute cooldown";
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
            oysterLevelText.text = "Max";
            oysterLevelDescription.text = "Lv Max Oyster\n36000 " + spriteAsset + "per bunch";
            oysterUpgradeValue.text = "20 minute cooldown";
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
