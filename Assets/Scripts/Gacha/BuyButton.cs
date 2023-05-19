using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GachaManager gm;
    public GameObject TransitionScreen; 

    [System.Serializable]
    public class FishUnlockData
    {
        public string checkInventory;
        public string unlockFishName;
        public GameObject toggle;
        public GameObject lockedToggle;
        public TMP_Text text;
        public GameObject objectToEnableCollider;
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

    private void Update() {
        Collider2D colliderToEnable = GetComponent<Collider2D>();
        if (TransitionScreen.activeSelf) {
            colliderToEnable.enabled = false;
        } 
        if (!TransitionScreen.activeSelf) {
            colliderToEnable.enabled = true;
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
