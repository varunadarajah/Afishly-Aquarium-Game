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
        pearlCost = 500;
    else if (currentLevel == 1)
        pearlCost = 2000;
    else if (currentLevel == 2)
        pearlCost = 5000;
    else if (currentLevel == 3)
        pearlCost = 10000;

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
        if(game.pearls >= 500 && currentLevel == 0 && accessLevel1)
        {
            ToggleObject();
            IncreaseLevel();
            accessLevel1 = false;
            musselLevelDescription.text = "Lv 1 Mussel\n5 " + spriteAsset + "per second";
            musselUpgradeValue.text = "5 > 10 " + spriteAsset + "per second";
            game.pearls -= 500;
            pearlCost = 2000;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel2()
    {
        if(game.pearls >= 2000 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            accessLevel2 = false;
            musselLevelDescription.text = "Lv 2 Mussel\n10 " + spriteAsset + "per second";
            musselUpgradeValue.text = "10 > 20 " + spriteAsset + "per second";
            game.pearls -= 2000;
            pearlCost = 5000;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel3()
    {
        if(game.pearls >= 5000 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            accessLevel3 = false;
            musselLevelDescription.text = "Lv 3 Mussel\n20 " + spriteAsset + "per second";
            musselUpgradeValue.text = "20 > 30 " + spriteAsset + "per second";
            game.pearls -= 5000;
            pearlCost = 10000;
            return true;
        }
        return false;
    }

     bool purchaseMaxLevel()
    {
        if(game.pearls >= 10000 && currentLevel == 3 && accessMaxLevel)
        {
            IncreaseLevel();
            accessMaxLevel = false;
            musselLevelText.text = "Max";
            musselLevelDescription.text = "Lv Max Mussel\n30 " + spriteAsset + "per second";
            musselUpgradeValue.text = "";
            game.pearls -= 10000;
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