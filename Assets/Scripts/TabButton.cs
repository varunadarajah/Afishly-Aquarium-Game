using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public TabManager tabs;

    public SpriteRenderer spriteRenderer;

    //  button effect
    public AudioSource buttonSFX;

    // Start is called before the first frame update
    void Start()
    {
        buttonSFX = GameObject.Find("ButtonSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

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
