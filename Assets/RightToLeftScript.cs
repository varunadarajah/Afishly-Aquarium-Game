using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftScript : MonoBehaviour
{
    public bool RightToLeft = false; 
    public RandomScript random; 
    public LeftToRightScript LTR;
    
    private void OnMouseDown() {
        RightToLeft = true; 
        random.random = false;
        LTR.LeftToRight = false; 
    }
}