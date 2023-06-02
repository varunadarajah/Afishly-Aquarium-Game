using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterTabButton : MonoBehaviour
{
    public FilterBoxManager tabs;

    public Image img;

    //  button effect
    public AudioSource buttonSFX;
    // Start is called before the first frame update
    void Start()
    {
        buttonSFX = GameObject.Find("ButtonSFX").GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if(tabs.curSelectedTab != this)
        {
            buttonSFX.Play();
            tabs.SelectTab(this);
        }        
    }
}
