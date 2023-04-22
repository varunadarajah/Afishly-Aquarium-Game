using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTurtleBox : MonoBehaviour
{
    public GameObject toggleUpArrow;
    public GameObject toggleDownArrow;
    public GameObject expandWindow;

 

    private void OnMouseDown()
    {
        toggleArrow();
    }

    void toggleArrow()
    {
        if (toggleUpArrow != null)
        {
            toggleUpArrow.SetActive(!toggleUpArrow.activeSelf);
        }
        if (toggleDownArrow != null)
        {
            toggleDownArrow.SetActive(!toggleDownArrow.activeSelf); 
        }
        if (expandWindow != null)
        {
            expandWindow.SetActive(!expandWindow.activeSelf);
        }
    }
}
