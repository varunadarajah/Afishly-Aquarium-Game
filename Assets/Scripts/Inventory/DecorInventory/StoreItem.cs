using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    public Game game;
    public GameObject parentObject;
    public Dictionary<string, DecorManager> decorManagers;

    public DecorManager Plant_1;
    public DecorManager Plant_2;
    public DecorManager Plant_3;
    public DecorManager Rock_1;
    public DecorManager Rock_2;
    public DecorManager Rock_3;

    private void Start()
    {
        // Initialize the decorManagers dictionary
        decorManagers = new Dictionary<string, DecorManager>();
        decorManagers.Add("Plant_1(Clone)", Plant_1);
        decorManagers.Add("Plant_2(Clone)", Plant_2);
        decorManagers.Add("Plant_3(Clone)", Plant_3);
        decorManagers.Add("Rock_1(Clone)", Rock_1);
        decorManagers.Add("Rock_2(Clone)", Rock_2);
        decorManagers.Add("Rock_3(Clone)", Rock_3);
    }

    private void OnMouseDown()
    {
        // Get all child objects of the parent object, including nested children
        PlantRock[] childPlantRocks = parentObject.GetComponentsInChildren<PlantRock>(true);

        foreach (PlantRock plantRock in childPlantRocks)
        {
            if (plantRock.selected)
            {
                string name = plantRock.transform.parent.gameObject.name;
                DecorManager decorManager;
                if (decorManagers.TryGetValue(name, out decorManager))
                {
                    // Destroy the object
                    Destroy(plantRock.gameObject);
                    // Call the storeDecor function in the DecorManager script
                    decorManager.storeDecor();
                }
            }
        }
    }
}
