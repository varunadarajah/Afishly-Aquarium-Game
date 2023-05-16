using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftScript : MonoBehaviour
{
    public bool RightToLeft = false; 
    public RandomScript random; 
    public LeftToRightScript LTR;

    public GameObject randomButton; 
    public GameObject LTRButton; 
    public GameObject RTLButton; 
    
    private void OnMouseDown() {
        RightToLeft = true; 
        random.random = false;
        LTR.LeftToRight = false; 
        randomButton.SetActive(false);
        LTRButton.SetActive(false);
        RTLButton.SetActive(true);
    }
}