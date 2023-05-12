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
      Collider2D[] childColliders = parentObject.GetComponentsInChildren<Collider2D>(true);
        foreach (Collider2D childCollider in childColliders)
        {
          childCollider.enabled = true;
        }
        EditModeButtons.SetActive(true);
        HomeButton.SetActive(false);
    }

}

