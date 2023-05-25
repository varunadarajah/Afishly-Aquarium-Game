using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishData
{
    public string fishBreed;
    public string fishName;
    public string dateObtained;
    public Color fishColor;
    public bool isActive = false;

    public FishData(Fish f)
    {
        fishBreed = f.fishBreed;
        fishName = f.fishName;
        dateObtained = f.dateObtained.ToString("G");
        fishColor = f.fishColor;
        isActive = f.isActive;
    }
}
