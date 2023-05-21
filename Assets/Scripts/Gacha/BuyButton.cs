using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GachaManager gm;

    public FishUnlockData[] fishUnlockDataArray;

    void OnMouseDown()
    {
        gm.buyBox();

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
}
