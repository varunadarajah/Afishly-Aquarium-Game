using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishActiveToggle : MonoBehaviour
{
    public bool isActive = true;
    public FishView box;

    public Sprite activeSlider;
    public Sprite inactiveSlider;

    public GameObject sliderCircle;

    // Start is called before the first frame update
    void Start()
    {
        isActive = box.fish.isActive;
        
        if(isActive)
        {
            sliderCircleOn();
        } 
        else
        {
            sliderCircleOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = activeSlider;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = inactiveSlider;
        }
    }

    void OnMouseDown()
    {
        toggleActive();
    }

    public void toggleActive()
    {
        if (isActive)
        {
            box.fish.isActive = false;
            box.fish.gameObject.SetActive(false);
            isActive = false;
            box.fm.activeCount--;
            box.fm.game.activeFish.Remove(box.fish);

            // move slider circle
            sliderCircleOff();
        }
        else if (box.fm.game.activeFish.Count < box.fm.game.activeFishMax)
        {
            box.fish.isActive = true;
            box.fish.gameObject.SetActive(true);
            isActive = true;
            box.fm.activeCount++;
            box.fm.game.activeFish.Add(box.fish);

            // move slider circle
            sliderCircleOn();
        }

        // sorting
        FilterBoxManager filter = box.fm.filter;
        filter.SelectTab(filter.curSelectedTab);
    }

    void sliderCircleOff()
    {
        Vector3 startPosition = sliderCircle.transform.localPosition;
        Vector3 targetPosition = new Vector3((float)-0.568, startPosition.y, startPosition.z);
        sliderCircle.transform.localPosition = targetPosition;
    }

    void sliderCircleOn()
    {
        Vector3 startPosition = sliderCircle.transform.localPosition;
        Vector3 targetPosition = new Vector3((float)0.568, startPosition.y, startPosition.z);
        sliderCircle.transform.localPosition = targetPosition;
    }
}
