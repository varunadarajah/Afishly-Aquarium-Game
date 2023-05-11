using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public List<Sprite> topLayers;
    public List<Sprite> bottomLayers;

    public SpriteRenderer topLayer;
    public SpriteRenderer bottomLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setBackground(int i)
    {
        topLayer.sprite = topLayers[i];
        bottomLayer.sprite = bottomLayers[i];
    }
}
