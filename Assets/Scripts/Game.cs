using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int pearls = 0;
    public TMP_Text pearlText;

    public List<Fish> fishInventory;
    public DecorInventory decorInventory;

    public List<GameObject> activeDecor;

    public List<Fish> activeFish;
    public int activeFishMax = 10;
    public TMP_Text fishText;


    public List<Fish> allFishPrefabs; // used for loading save
    public GameObject FishParentObject; // where to instantiate fish
    public BuyButton fishUnlock; // to unlock fish in inventory

    // stats variables
    public int totalPearls = 0;
    public int totalClicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        Invoke("SaveGame", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // update currency
        pearlText.text = pearls + "";

        // update fish count
        fishText.text = activeFish.Count + "/" + activeFishMax;
    }

    public void SaveGame()
    {
        SaveManager.Save(this);
        Invoke("SaveGame", 10f); // saves every 10 seconds
    }

    public void LoadGame()
    {
        SaveData data = SaveManager.Load();
        if(data != null)
        {
            pearls = data.pearls;

            // load fish data
            foreach(FishData fishData in data.fishInventory)
            {
                foreach(Fish prefab in allFishPrefabs) // find matching prefab to instantiate
                {
                    if(fishData.fishBreed == prefab.fishBreed)
                    {
                        Fish f = Instantiate(prefab, FishParentObject.transform); // instantiate
                        f.gameObject.SetActive(true);

                        // load data
                        f.fishName = fishData.fishName;
                        f.dateObtained = fishData.dateObtained;
                        f.fishColor = fishData.fishColor;
                        f.isActive = fishData.isActive;                        
                        fishInventory.Add(f);

                        // unlock fish in inventory
                        foreach (FishUnlockData fishUnlockData in fishUnlock.fishUnlockDataArray)
                        {
                            fishUnlock.UnlockFish(fishUnlockData);
                        }

                        f.gameObject.SetActive(false);

                        if (f.isActive) // set active if was active
                        {
                            activeFish.Add(f);
                            f.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }       
    }
}
