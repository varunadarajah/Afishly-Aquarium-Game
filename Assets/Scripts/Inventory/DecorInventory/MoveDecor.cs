using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecor : MonoBehaviour
{
    public GameObject EditModeButtons;

    public GameObject MoveDecorScreen;
    
    public Game game;
    public GameObject parentObject;

    private void OnMouseDown()  
{
    // get child objects of the parent object
    Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>();

    foreach (Transform childObject in childObjects)
    {
        // check if the child object has a PlantRock component
        PlantRock plantRock = childObject.GetComponent<PlantRock>();
        if (plantRock != null && plantRock.selected)
        {
            plantRock.canMove = true;
            EditModeButtons.SetActive(false);
            MoveDecorScreen.SetActive(true);
            PlantRock[] plantRocks = FindObjectsOfType<PlantRock>();
            foreach (PlantRock otherPlantRock in plantRocks)
            {
                if (otherPlantRock.gameObject != gameObject && otherPlantRock.selected == false)
                {
                    Collider2D[] colliders = otherPlantRock.GetComponents<Collider2D>();
                    foreach (Collider2D collider in colliders)
                    {
                        collider.enabled = false;
                    }
                }
            }
        }
        }
    }
}

