using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrechDownScript : MonoBehaviour
{
public GameObject objectToToggle;
   void OnMouseDown() 
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf); // Toggle the active state of the other object
        }
    }
}
