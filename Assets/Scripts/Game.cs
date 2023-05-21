using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int pearls = 0;
    public TMP_Text pearlText;

    public List<Fish> fishInventory;
    public List<FishHistoryRecord> fishHistory;

    public DecorInventory decorInventory;
    public List<GameObject> activeDecor;

    public List<Fish> activeFish;
    public int activeFishMax = 10;
    public TMP_Text fishText;


    public List<Fish> allFishPrefabs; // used for loading save
    public GameObject FishParentObject; // where to instantiate fish
    public BuyButton fishUnlock; // to unlock fish in inventory

    public LevelUpClamScript clamData;
    public ExpandScript expandData;

    public BackgroundButtonManager bg;

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
        if (data != null)
        {
            // load pearls
            pearls = data.pearls;

            // load expand data
            for(int i = 1; i < data.expandLevel; i++)
            {
                pearls += expandData.pearlCost;
                expandData.OnMouseDown();
                expandData.OnMouseDown();
            }

            // load fish data
            foreach (FishData fishData in data.fishInventory)
            {
                foreach (Fish prefab in allFishPrefabs) // find matching prefab to instantiate
                {
                    if (fishData.fishBreed == prefab.fishBreed)
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

            // load plant data
            foreach (DecorData decorData in data.plants)
            {
                foreach (DecorManager decor in decorInventory.plants)
                {
                    if(decorData.decorName == decor.decorName)
                    {
                        decor.inactiveCount = decorData.inactiveCount + decorData.activeCount;
                        for (int i = 0; i < decorData.activeCount; i++)
                        {
                            decor.placeDecor();
                        }
                    }
                }
            }

            // load rock data
            foreach (DecorData decorData in data.rocks)
            {
                foreach (DecorManager decor in decorInventory.rocks)
                {
                    if (decorData.decorName == decor.decorName)
                    {
                        decor.inactiveCount = decorData.inactiveCount + decorData.activeCount;
                        for(int i = 0; i < decorData.activeCount; i++)
                        {
                            decor.placeDecor();
                        }
                    }
                }
            }

            // load active decor data
            List<int> loadedDecor = new();            
            for (int i = 0; i < data.activeDecor.Count; i++)
            {                
                ActiveDecorData decorData = data.activeDecor[i];

                for(int j = 0; j < activeDecor.Count; j++)
                {
                    if((activeDecor[j].name == decorData.decorName) && !(loadedDecor.Contains(j)))
                    {
                        activeDecor[j].transform.position = decorData.decorPosition;
                        activeDecor[j].transform.localScale = decorData.decorScale;

                        loadedDecor.Add(j);
                        j = activeDecor.Count;
                    }
                }
            }

            // load mollusk data
            MolluskData molluskData = data.molluskData;
            // clam
            for (int i = 1; i < molluskData.clamLevel; i++)
            {
                pearls += clamData.pearlCost;
                clamData.OnMouseDown();
                clamData.OnMouseDown();
            }

            // mussel
            for (int i = 0; i < molluskData.musselLevel; i++)
            {
                pearls += clamData.unlockMussel.pearlCost;
                clamData.unlockMussel.OnMouseDown();
                clamData.unlockMussel.OnMouseDown();
            }

            // oyster
            for (int i = 0; i < molluskData.oysterLevel; i++)
            {
                pearls += clamData.unlockOyster.pearlCost;
                clamData.unlockOyster.OnMouseDown();
                clamData.unlockOyster.OnMouseDown();
            }

            // load background
            bg.currentBackground = data.currentBg;
        }
    }

    // when app is exited
    // this currently kinda bugged atleast in unity, it saves right when the game starts before previous save is loaded
    void OnApplicationPause() 
    {
        //SaveGame();
    }

    // when app is closed out
    void OnApplicationQuit() // this works
    {
        SaveGame();
    }
}
