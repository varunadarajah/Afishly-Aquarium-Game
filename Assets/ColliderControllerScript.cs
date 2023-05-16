using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControllerScript : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject editMode; 
    public GameObject editModeScreen;
    public GameObject MoveDecorScreen;
    private void Update() {
      if (editMode.activeSelf && editModeScreen.activeSelf) {
        Collider2D[] childColliders = parentObject.GetComponentsInChildren<Collider2D>(true);
        foreach (Collider2D childCollider in childColliders)
        {
          childCollider.enabled = true;
        } 
    //   } else {
    //     Collider2D[] childColliders = parentObject.GetComponentsInChildren<Collider2D>(true);
    //     foreach (Collider2D childCollider in childColliders)
    //     {
    //         childCollider.enabled = false;
    //     }
    //   }
    // if (MoveDecorScreen.activeSelf) {
    
    // }
    }
}
}
