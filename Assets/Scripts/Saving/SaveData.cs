using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int pearls = 0;

    public List<FishData> fishInventory = new List<FishData>();
    //public DecorInventory decorInventory;

    public SaveData(Game g)
    {
        pearls = g.pearls;

        foreach (Fish f in g.fishInventory)
        {
            FishData fishData = new FishData(f);
            fishInventory.Add(fishData);
        } 
    }
}
