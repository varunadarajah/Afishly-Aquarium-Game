using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GachaManager gm;

    public FishUnlockData[] fishUnlockDataArray;

    void Start()
    {
        LoadFishUnlockData();
    }

    void OnApplicationQuit()
    {
        SaveFishUnlockData();
    }

    void OnMouseDown()
    {
        gm.buyBox();
    }
    
    void Update() 
    { 
        foreach (FishUnlockData fishUnlockData in fishUnlockDataArray)
        {
            UnlockFish(fishUnlockData);
        }
    }

    public void UnlockFish(FishUnlockData fishUnlockData)
    {
        GameObject fishLocked = GameObject.Find(fishUnlockData.checkInventory);

        if (fishLocked != null && !fishUnlockData.toggle.activeSelf)
        {
            fishUnlockData.isFound = true;
        }

            if (fishUnlockData.isFound)
            {
                fishUnlockData.toggle.SetActive(true);
                fishUnlockData.lockedToggle.SetActive(false);
                fishUnlockData.text.text = fishUnlockData.unlockFishName;

                if (fishUnlockData.objectToEnableCollider != null)
                {
                    Button colliderToEnable = fishUnlockData.objectToEnableCollider.GetComponent<Button>();
                    if (colliderToEnable != null)
                    {
                        colliderToEnable.enabled = true;
                    }
                }
            }
    }

    private void SaveFishUnlockData()
    {
        for (int i = 0; i < fishUnlockDataArray.Length; i++)
        {
            string key = "FishUnlockData_" + i.ToString();
            int value = fishUnlockDataArray[i].isFound ? 1 : 0;
            PlayerPrefs.SetInt(key, value);
        }

        PlayerPrefs.Save();
    }

    private void LoadFishUnlockData()
    {
        for (int i = 0; i < fishUnlockDataArray.Length; i++)
        {
            string key = "FishUnlockData_" + i.ToString();
            int value = PlayerPrefs.GetInt(key, 0);
            fishUnlockDataArray[i].isFound = value == 1;
        }
    }
}

