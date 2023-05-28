using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterBoxManager : MonoBehaviour
{
    public FishViewManager fm;

    public List<FilterTabButton> tabButtons;
    public FilterTabButton curSelectedTab;

    public Sprite tabSelected;
    public Sprite tabUnselected;

    // Start is called before the first frame update
    void Start()
    {
        //setDefaultTab();
    }

    public void setDefaultTab()
    {
        SelectTab(tabButtons[0]);
    }

    public void SelectTab(FilterTabButton t)
    {
        if (t != null) // if menu activated
        {
            curSelectedTab = t;


            ResetTabs();
            t.img.sprite = tabSelected;


            int index = t.transform.GetSiblingIndex();

            switch (index)
            {
                case 0:
                    sortAsc();
                    break;
                case 1:
                    sortDesc();
                    break;
                case 2:
                    sortActive();
                    break;
                case 3:
                    sortInvactive();
                    break;
                case 4:
                    sortAlphabetical();
                    break;
            }
        }
    }

    public void ResetTabs()
    {
        foreach(FilterTabButton t in tabButtons)
        {
            if(curSelectedTab != t)
            {
                t.img.sprite = tabUnselected;
            }
        }
    }

    public void ResetSort()
    {
        fm.SetFish(fm.breedText.text);
    }

    public void sort()
    {
        SelectTab(curSelectedTab);
    }

    public void sortAsc()
    {
        List<DateTime> dateList = new List<DateTime>();

        foreach (GameObject box in fm.boxes)
        {
            dateList.Add(box.GetComponent<FishView>().fish.dateObtained);
        }

        dateList.Sort();

        foreach (DateTime fishDate in dateList)
        {
            foreach (GameObject box in fm.boxes)
            {
                if (fishDate.Equals(box.GetComponent<FishView>().fish.dateObtained))
                {
                    box.transform.SetAsLastSibling();
                }
            }
        }
    }

    public void sortDesc()
    {
        sortAsc();
        List<DateTime> dateList = new List<DateTime>();

        foreach (GameObject box in fm.boxes)
        {
            dateList.Add(box.GetComponent<FishView>().fish.dateObtained);
        }

        dateList.Sort();

        foreach (DateTime fishDate in dateList)
        {
            foreach (GameObject box in fm.boxes)
            {
                if (fishDate.Equals(box.GetComponent<FishView>().fish.dateObtained))
                {
                    box.transform.SetAsFirstSibling();
                }
            }
        }
    }

    public void sortActive()
    {
        sortAsc();
        foreach (GameObject box in fm.boxes)
        {
            if(box.GetComponent<FishView>().fish.isActive)
            {
                box.transform.SetAsFirstSibling();
            }
        }
    }

    public void sortInvactive()
    {
        sortAsc();
        foreach (GameObject box in fm.boxes)
        {
            if (box.GetComponent<FishView>().fish.isActive)
            {
                box.transform.SetAsLastSibling();
            }
        }
    }

    public void sortAlphabetical()
    {
        sortAsc();
        List<string> nameList = new List<string>();

        foreach (GameObject box in fm.boxes)
        {
            nameList.Add(box.GetComponent<FishView>().fish.fishName);
        }

        nameList.Sort();

        foreach (string fishName in nameList)
        {
            foreach (GameObject box in fm.boxes)
            {
                if (fishName == (box.GetComponent<FishView>().fish.fishName))
                {
                    box.transform.SetAsLastSibling();
                }
            }
        }
    }
}
