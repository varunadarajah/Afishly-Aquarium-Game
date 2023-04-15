using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    public GachaManager gm;
    void OnMouseDown()
    {
        gm.ScrollRight();
    }
}
