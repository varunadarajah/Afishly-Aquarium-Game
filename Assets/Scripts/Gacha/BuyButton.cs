using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GachaManager gm;

    [System.Serializable]
    public class FishUnlockData
    {
        public string checkInventory;
        public string unlockFishName;
        public GameObject toggle;
        public GameObject lockedToggle;
        public TMP_Text text;
    }

    public FishUnlockData[] fishUnlockDataArray;

    void OnMouseDown()
    {
        gm.buyBox();

        foreach (FishUnlockData fishUnlockData in fishUnlockDataArray)
        {
            UnlockFish(fishUnlockData);
        }
    }

    void UnlockFish(FishUnlockData fishUnlockData)
    {
        GameObject fishLocked = GameObject.Find(fishUnlockData.checkInventory);

        if (fishLocked != null && !fishUnlockData.toggle.activeSelf)
        {
            fishUnlockData.toggle.SetActive(true);
            fishUnlockData.lockedToggle.SetActive(false);
            fishUnlockData.text.text = fishUnlockData.unlockFishName;
        }
    }
}
