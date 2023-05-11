using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{
    public bool random = false; 
    public LeftToRightScript LTR; 
    public RightToLeftScript RTL; 
    
    private void OnMouseDown() {
        random = true; 
        LTR.LeftToRight = false;
        RTL.RightToLeft = false; 
    }
}
