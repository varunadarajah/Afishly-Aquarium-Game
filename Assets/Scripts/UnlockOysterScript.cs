using System.Collections;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
{
    if (currentLevel == 0)
    {
        unlockOyster();
    }
    else if (currentLevel == 1)
    {
        purchaseLevel2();
    }
    else if (currentLevel == 2)
    {
        purchaseLevel3();
    }
}

    void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    bool unlockOyster()
    {
        if(game.pearls >= 50 && currentLevel == 0 && accessLevel1)
        {
            ToggleObject();
            IncreaseLevel();
            accessLevel1 = false;
            oysterLevelText.text = "Level Up\n100 " + spriteAsset;
            oysterLevelDescription.text = "Lv 1 Oyster\n50 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "50 > 100 " + spriteAsset + "per tap\n10 second cooldown";
            game.pearls -= 50;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel2()
    {
        if(game.pearls >= 100 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            accessLevel2 = false;
            oysterLevelText.text = "Level Up\n200 " + spriteAsset;
            oysterLevelDescription.text = "Lv 2 Oyster\n100 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "100 > 300 " + spriteAsset + "per tap\n10 second cooldown";
            game.pearls -= 100;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel3()
    {
        if(game.pearls >= 200 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            accessLevel3 = false;
            oysterLevelText.text = "Level Up\n300 " + spriteAsset;
            oysterLevelDescription.text = "Lv 3 Oyster\n300 " + spriteAsset + "per tap";
            oysterUpgradeValue.text = "300 > 500 " + spriteAsset + "per tap\n10 second cooldown";
            game.pearls -= 200;
            //close menu
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
