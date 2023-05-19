using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
