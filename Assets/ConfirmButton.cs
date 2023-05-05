using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject EditModeButtons;

    public GameObject MoveDecorScreen;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>();
        foreach (Transform childObject in childObjects)
        {
        PlantRock plantRock = childObject.GetComponent<PlantRock>();
            if (plantRock != null) 
            {
            plantRock.canMove = false;
            }
        EditModeButtons.SetActive(true);
        MoveDecorScreen.SetActive(false);
    }
}
}
