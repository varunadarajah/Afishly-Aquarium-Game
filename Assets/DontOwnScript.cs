using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DontOwnScript : MonoBehaviour
{
    private FishViewManager fishViewManager;
    public TMP_Text textObject;
    public BuyButton buyButton;

    private void Update()
    {
        fishViewManager = FindObjectOfType<FishViewManager>();

        if (fishViewManager != null && buyButton != null && buyButton.fishUnlockDataArray != null)
        {
            bool anyFishFound = false;

            foreach (FishUnlockData fishUnlockData in buyButton.fishUnlockDataArray)
            {
                if (fishUnlockData.isFound)
                {
                    anyFishFound = true;
                    break;
                }
            }

            if (anyFishFound && fishViewManager.ownedCount == 0)
            {
                textObject.gameObject.SetActive(true);
            }
            else
            {
                textObject.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("FishViewManager or BuyButton or fishUnlockDataArray not found.");
        }
    }
}
