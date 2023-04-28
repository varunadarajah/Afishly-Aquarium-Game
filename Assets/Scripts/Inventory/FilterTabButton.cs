using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterTabButton : MonoBehaviour
{
    public FilterBoxManager tabs;

    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        tabs.SelectTab(this);
    }
}
