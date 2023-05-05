using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public TabButton defaultTab; // tab to open with on start
    public List<TabButton> tabButtons;
    public TabButton curSelectedTab;

    public Sprite tabSelected;
    public Sprite tabUnselected;

    public List<GameObject> tabPages;
    // order:
    // [0] Fish
    // [1] Clams
    // [2] Expand
    // [3] Decor.

    void Start()
    {
        if(defaultTab == null)
        {
            SelectTab(tabButtons[0]);
        }
        else
        {
            SelectTab(defaultTab);
        }
    }

    public void AddTab(TabButton t)
    {
        tabButtons.Add(t);
    }

    public void SelectTab(TabButton t)
    {
        curSelectedTab = t;
        ResetTabs();
        t.spriteRenderer.sprite = tabSelected;

        int index = t.transform.GetSiblingIndex();
        for(int i = 0; i < tabButtons.Count; i++)
        {
            if(i == index)
            {
                tabPages[i].SetActive(true);
            } else
            {
                tabPages[i].SetActive(false);
            }
        }
    }

    public void UnselectTab()
    {
        ResetTabs();
    }

    public void ResetTabs()
    {
        foreach(TabButton t in tabButtons)
        {
            if(curSelectedTab != t)
            {
                t.spriteRenderer.sprite = tabUnselected;
            }
        }
    }
}
