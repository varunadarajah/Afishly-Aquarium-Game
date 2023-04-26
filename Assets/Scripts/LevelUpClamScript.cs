using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpClamScript : MonoBehaviour
{
    public Game game;
    public int currentLevel = 1; // Add a level variable to keep track of the object's level
    public Clam clamUpgrade;
    public TMP_Text clamLevelText;
    public TMP_Text clamLevelDescription;
    public TMP_Text clamUpgradeValue;
    string spriteAsset = "<sprite name=\"Pearl\">";
    bool accessLevel2 = true;
    bool accessLevel3 = true;
    bool accessLevel4 = true;

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
    if (currentLevel == 1)
    {
        purchaseLevel2();
    }
    else if (currentLevel == 2)
    {
        purchaseLevel3();
    }
    else if (currentLevel == 3)
    {
        purchaseLevel4();
    }
}

    void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    bool purchaseLevel2()
    {
        if (game.pearls >= 50 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 1;
            accessLevel2 = false;
            clamLevelText.text = "Level Up\n100 " + spriteAsset;
            clamLevelDescription.text = "Lv 2 Regular Clam\n6 " + spriteAsset + "per tap";
            clamUpgradeValue.text = "6 > 8 " + spriteAsset + "per tap";
            game.pearls -= 50;
            return true;
        }
        return false;
    }

    bool purchaseLevel3()
    {
        if (game.pearls >= 100 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 2;
            accessLevel3 = false;
            clamLevelText.text = "Level Up\n200 " + spriteAsset;
            clamLevelDescription.text = "Lv 3 Regular Clam\n8 " + spriteAsset + "per tap";
            clamUpgradeValue.text = "8 > 10 " + spriteAsset + "per tap";
            game.pearls -= 100;
            //close menu
            return true;
        }
        return false;
    }

   bool purchaseLevel4()
{
    if (game.pearls >= 200 && currentLevel == 3 && accessLevel4)
    {
        IncreaseLevel();
        clamUpgrade.pearlPerTap += 2;
        accessLevel4 = false;
        clamLevelText.text = "Level Up\n500 " + spriteAsset;
        clamLevelDescription.text = "Lv 4 Regular Clam\n10 " + spriteAsset + "per tap";
        clamUpgradeValue.text = "10 > 15 " + spriteAsset + "per tap";
        game.pearls -= 200;

        return true;
    }
    return false;
}



}
