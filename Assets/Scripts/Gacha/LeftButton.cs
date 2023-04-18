using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    public GachaManager gm;
    void OnMouseDown()
    {
        gm.ScrollLeft();
    }
}
