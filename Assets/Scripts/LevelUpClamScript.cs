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
        purchaseLevel2();
        purchaseLevel3();
        purchaseLevel4();
    }

    void IncreaseLevel()
    {
        currentLevel++; // Increase the level of the object by 1
    }

    bool purchaseLevel2()
    {
        if(game.pearls >= 50 && currentLevel == 1 && accessLevel2)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 1; 
            accessLevel2 = false;
            clamLevelText.text = "Level Up\n100";
            clamLevelDescription.text = "Lv 2 Regular Clam\n6\t per tap\n\n\n\n6 > 8 per tap";
            game.pearls -= 50;
            return true; 
        }
        return false; 
    }

    bool purchaseLevel3()
    {
        if(game.pearls >= 100 && currentLevel == 2 && accessLevel3)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 2; 
            accessLevel3 = false;
            clamLevelText.text = "Level Up\n200";
            clamLevelDescription.text = "Lv 3 Regular Clam\n8\t per tap\n\n\n\n8 > 10 per tap";
            game.pearls -= 100;
            //close menu
            return true;
        }
        return false;
    }

     bool purchaseLevel4()
    {
        if(game.pearls >= 200 && currentLevel == 3 && accessLevel4)
        {
            IncreaseLevel();
            clamUpgrade.pearlPerTap += 2; 
            accessLevel4 = false;
            clamLevelText.text = "Level Up\n500";
            clamLevelDescription.text = "Lv 4 Regular Clam\n10\t per tap\n\n\n\n10 > 15 per tap";
            game.pearls -= 200;
            return true; 
        }
        return false; 
    }
}
