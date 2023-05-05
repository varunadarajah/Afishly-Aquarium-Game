using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecor : MonoBehaviour
{
    private bool isPickedUp = false;
    private Vector3 mousePositionOffset;
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
            }
        }
    }
}
