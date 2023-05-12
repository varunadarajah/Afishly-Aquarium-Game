using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{
    public bool random = true; 
    public LeftToRightScript LTR; 
    public RightToLeftScript RTL; 

    public GameObject randomButton; 
    public GameObject LTRButton; 
    public GameObject RTLButton; 
    
    private void OnMouseDown() {
        random = true; 
        LTR.LeftToRight = false;
        RTL.RightToLeft = false; 
        randomButton.SetActive(true);
        LTRButton.SetActive(false);
        RTLButton.SetActive(false);
    }
}
