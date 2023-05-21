using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActiveDecorData
{
    public string decorName;
    public Vector3 decorPosition;
    public Vector3 decorScale;

    public ActiveDecorData(GameObject d)
    {
        decorName = d.name;
        decorPosition = d.transform.position;
        decorScale = d.transform.localScale;
    }
}