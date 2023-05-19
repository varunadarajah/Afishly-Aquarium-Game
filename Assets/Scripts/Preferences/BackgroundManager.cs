using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Game game;

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
        CancelInvoke();
        topLayer.sprite = topLayers[i];
        bottomLayer.sprite = bottomLayers[i];
    }

    public void RandomBackground()
    {
        int random = UnityEngine.Random.Range(0, topLayers.Count - 1);
        setBackground(random);

        // recall function at random time
        float randomTime = UnityEngine.Random.Range(60f, 300f);
        Invoke("RandomBackground", randomTime);
    }

    public void AutoBackground()
    {
        CancelInvoke();

        if(game.fishInventory.Count == 0) // if no fish, then set default background
        {
            setBackground(0);
            return;
        }

        float fishColorAvg = 0;

        foreach (Fish f in game.fishInventory)
        {
            float H, S, V;
            Color.RGBToHSV(f.fishColor, out H, out S, out V);

            fishColorAvg += H;
        }

        fishColorAvg /= game.fishInventory.Count;

        Debug.Log(fishColorAvg);

        if(fishColorAvg <= 0.13 || fishColorAvg >= 0.9)
        {
            setBackground(5);
        } 
        else
        {
            setBackground(0);
        }
    }
}
