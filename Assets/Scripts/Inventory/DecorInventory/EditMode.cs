using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMode : MonoBehaviour
{
    public GameObject EditModeButtons;
    public GameObject HomeButton;

      public GameObject parentObject;

    private void OnMouseDown()
    {
        EditModeButtons.SetActive(true);
        HomeButton.SetActive(false);
    }

}

