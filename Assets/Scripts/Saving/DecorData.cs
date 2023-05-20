using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecorData
{
    public string decorName;

    public int inactiveCount;
    public int activeCount;

    public DecorData(DecorManager d)
    {
        decorName = d.decorName;
        inactiveCount = d.inactiveCount;
        activeCount = d.activeCount;
    }
}
