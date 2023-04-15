using System.Collections;
using UnityEngine;
using TMPro;

public class UnlockMusselScript : MonoBehaviour
{
    public Game game;
    public int currentLevel = 0; // Add a level variable to keep track of the object's level
    public int musselPearls;
    public TMP_Text musselLevelText;
    public TMP_Text musselLevelDescription;
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
        unlockMussel();
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

    bool unlockMussel()
    {
        if(game.pearls >= 50 && currentLevel == 0 && accessLevel1)
        {
            ToggleObject();
            IncreaseLevel();
            StartCoroutine(IncreasePearls());
            accessLevel1 = false;
            musselLevelText.text = "Level Up\n100";
            musselLevelDescription.text = "Lv 1 Mussel\n5\t per second\n\n\n\n5 > 6 per second";
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
            musselLevelText.text = "Level Up\n200";
            musselLevelDescription.text = "Lv 2 Mussel\n6\t per second\n\n\n\n6 > 8 per second";
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
            musselLevelText.text = "Level Up\n300";
            musselLevelDescription.text = "Lv 3 Mussel\n8\t per second\n\n\n\n8 > 10 per second";
            game.pearls -= 200;
            //close menu
            return true;
        }
        return false;
    }

    IEnumerator IncreasePearls() {
        while (true) {
            yield return new WaitForSeconds(1f); // Wait for 1 second

            int pearlsPerSecond = 5;

        // Increase pearls per second to 6 at level 2
            if (currentLevel == 2)
            {
              pearlsPerSecond = 6;
            }

          if (currentLevel == 3)
            {
            pearlsPerSecond = 8;
            }

        // Increase pearls in the other object by pearlsPerSecond
        game.pearls += pearlsPerSecond;
        }
    }
    void ToggleObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf); // Toggle the active state of the other object
        }
    }
}
