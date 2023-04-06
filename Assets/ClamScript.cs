using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClamScript : MonoBehaviour
{
    public int numCollected = 0;

public TMP_Text pearlText;

void Start()
{
    // Store the initial position of the object
}

// Update is called once per frame
void Update()
{
    pearlText.text = " " +numCollected;
}

void OnMouseDown() {
    numCollected += 5; 
}
}
