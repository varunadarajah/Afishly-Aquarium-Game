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
    bool accessMaxLevel = true;


    public GameObject GrayLayer;

    public Button button;
    public int pearlCost;
    public int clickCount;

    public LevelUpClamScript levelUpClam;
    public UnlockMusselScript unlockMussel;

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
        pearlCost = 1000;
    else if (currentLevel == 1)
        pearlCost = 5000;
    else if (currentLevel == 2)
        pearlCost = 10000;
    else if (currentLevel == 3)
        pearlCost = 30000;

    button.interactable = game.pearls >= pearlCost;
    GrayLayer.SetActive(!button.interactable);

    if (clickCount == 0)
    {
        if (accessMaxLevel)
        {
            if (currentLevel == 0) {
                oysterLevelText.text = $"Unlock Up\n{pearlCost} {spriteAsset}";
            }

            oysterLevelText.text = $"Level Up\n{pearlCost} {spriteAsset}";
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

    void OnMouseDown()
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
                purchaseMaxLevel();
                clickCount = 0; 
            }
        }
    }

    void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    bool unlockOyster()
    {
        if(game.pearls >= 1000 && currentLevel == 0 && accessLevel1)
        {
            ToggleObject();
            IncreaseLevel();
            accessLevel1 = false;
            oysterLevelDescription.text = "Lv 1 Oyster\n100 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "100 > 250 " + spriteAsset + "per tap\n1 minute cooldown";
            game.pearls -= 1000;
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
            oysterLevelDescription.text = "Lv 2 Oyster\n250 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "250 > 500 " + spriteAsset + "per tap\n1 minute cooldown";
            game.pearls -= 5000;
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
            oysterLevelDescription.text = "Lv 3 Oyster\n500 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "500 > 1000 " + spriteAsset + "per tap\n1 minute cooldown";
            game.pearls -= 10000;
            //close menu
            return true;
        }
        return false;
    }

     bool purchaseMaxLevel()
    {
        if(game.pearls >= 30000 && currentLevel == 3 && accessMaxLevel)
        {
            IncreaseLevel();
            accessMaxLevel = false;
            oysterLevelText.text = "Max";
            oysterLevelDescription.text = "Lv Max Oyster\n1000 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "1 minute cooldown";
            game.pearls -= 30000;
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
