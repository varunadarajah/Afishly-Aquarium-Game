using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DontOwnScript : MonoBehaviour
{
    private FishViewManager fishViewManager;
    public TMP_Text textObject;

    private void Update()
    {
        fishViewManager = FindObjectOfType<FishViewManager>();

        if (fishViewManager != null)
        {
            int ownedCount = fishViewManager.ownedCount;

            if (ownedCount == 0)
            {
                textObject.gameObject.SetActive(true); 
                // Debug.Log(ownedCount);
            }
            else
            {
                textObject.gameObject.SetActive(false);
                // Debug.Log(ownedCount + "False");
            }
        }
        else
        {
            Debug.LogWarning("FishViewManager not found in the scene.");
        }
    }
}
