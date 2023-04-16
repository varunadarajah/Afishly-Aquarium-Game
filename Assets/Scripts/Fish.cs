using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public string fishBreed;
    public string fishName;
    public string dateObtained;
    public Color fishColor;

    // Start is called before the first frame update
    void Start()
    {
        dateObtained = System.DateTime.UtcNow.ToLocalTime().ToString("MM/dd/yyyy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
