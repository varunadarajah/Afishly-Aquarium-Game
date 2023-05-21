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
        CancelInvoke();
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

        foreach (Fish f in game.activeFish)
        {
            float H, S, V;
            Color.RGBToHSV(f.fishColor, out H, out S, out V);

            fishColorAvg += H;
        }

        fishColorAvg /= game.activeFish.Count;

        Debug.Log(fishColorAvg);

        if(fishColorAvg <= 0.12 || fishColorAvg >= 0.92) // red
        {
            setBackground(5);
        } 
        else if(fishColorAvg > 0.12 && fishColorAvg <= 0.34) // green
        {
            setBackground(2);
        }
        else if (fishColorAvg > 0.34 && fishColorAvg <= 0.42) // bluegreen 1
        {
            setBackground(6);
        }
        else if (fishColorAvg > 0.42 && fishColorAvg <= 0.5) // bluegreen 2
        {
            setBackground(7);
        }
        else if (fishColorAvg > 0.5 && fishColorAvg <= 0.74) // blue
        {
            setBackground(0);
        }
        else if (fishColorAvg > 0.74 && fishColorAvg <= 0.8) // purple
        {
            setBackground(1);
        }
        else if (fishColorAvg > 0.8 && fishColorAvg <= 0.88) // light purple/pink?
        {
            setBackground(3);
        }
        else if (fishColorAvg > 0.88 && fishColorAvg < 0.92) // light red/pink
        {
            setBackground(4);
        }
        else
        {
            setBackground(0);
        }
        Invoke("AutoBackground", 0f);
    }
}
