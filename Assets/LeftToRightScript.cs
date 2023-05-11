using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightScript : MonoBehaviour
{
    public bool LeftToRight = false; 
    public RandomScript random; 
    public RightToLeftScript RTL;
    
    private void OnMouseDown() {
        LeftToRight = true; 
        random.random = false;
        RTL.RightToLeft = false; 
    }
}
