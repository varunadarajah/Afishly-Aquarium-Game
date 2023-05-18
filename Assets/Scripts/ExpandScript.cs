using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
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

    public void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    public bool purchaseLevel2()
    {
        if (game.pearls >= 100 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            game.activeFishMax = 15;
            accessLevel2 = false;
            expandLevelText.text = "Level Up\n200 " + spriteAsset;
            expandLevelDescription.text = "Lv 2 Freshwater Tank\nCurrent: 15 max fish";
            expandUpgradeValue.text = "15 > 20 max fish";
            game.pearls -= 100;
            return true;
        }
        return false;
    }

    public bool purchaseLevel3()
    {
        if (game.pearls >= 200 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            game.activeFishMax = 20;
            accessLevel3 = false;
            expandLevelText.text = "Level Up\n300 " + spriteAsset;
            expandLevelDescription.text = "Lv 3 Freshwater Tank\nCurrent: 20 max fish";
            expandUpgradeValue.text = "20 > 25 max fish";
            game.pearls -= 200;
            //close menu
            return true;
        }
        return false;
    }

   public bool purchaseLevel4()
    {
    if (game.pearls >= 300 && currentLevel == 3 && accessLevel4)
    {
        IncreaseLevel();
        game.activeFishMax = 25;
        accessLevel4 = false;
        expandLevelText.text = "Level Up\n500 " + spriteAsset;
        expandLevelDescription.text = "Lv 4 Freshwater Tank\nCurrent: 25 max fish";
        expandUpgradeValue.text = "Max Level";
        game.pearls -= 300;

        return true;
    }
    return false;
}
}
