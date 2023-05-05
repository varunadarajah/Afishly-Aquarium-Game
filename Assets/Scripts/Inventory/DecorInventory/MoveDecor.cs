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
        if (plantRock != null)
        {
            if (plantRock == this) // if this is the clicked object
            {
                // set its canMove flag to true and selected flag to true
                plantRock.canMove = true;
                plantRock.selected = true;
            }
            else // if this is not the clicked object
            {
                // set its canMove flag to false and selected flag to false
                plantRock.canMove = false;
                plantRock.selected = false;
            }
        }
    }

    // hide edit mode buttons and show move decor screen
    EditModeButtons.SetActive(false);
    MoveDecorScreen.SetActive(true);
}

}
