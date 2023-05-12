using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightScript : MonoBehaviour
{
    public bool LeftToRight = false; 
    public RandomScript random; 
    public RightToLeftScript RTL;

    public GameObject randomButton; 
    public GameObject LTRButton; 
    public GameObject RTLButton; 
    
    private void OnMouseDown() {
        LeftToRight = true; 
        random.random = false;
        RTL.RightToLeft = false; 
        randomButton.SetActive(false);
        LTRButton.SetActive(true);
        RTLButton.SetActive(false);
    }
}
