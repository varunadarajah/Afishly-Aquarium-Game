using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTabOnOpen : MonoBehaviour
{
    public TabManager tabManager;

    private void OnMouseDown()
    {
        tabManager.SelectTab(tabManager.defaultTab);
    }
}
