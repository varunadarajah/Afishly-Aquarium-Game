using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PearlScript : MonoBehaviour
{
    public int numCollected = 0;

 public float speed = 5f; // Speed at which the object will move down
public float bottomY = -5; 

public TMP_Text pearlText;

private Vector3 initialPosition; // The initial position of the object

void Start()
{
    // Store the initial position of the object
    initialPosition = transform.position;
}

// Update is called once per frame
void Update()
{
    pearlText.text = " " +numCollected;
    if (transform.position.y > bottomY)
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
    else
    {
        transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
    }
}

void OnMouseDown() {
    numCollected++; 
    float randomX = Random.Range(-2f, 2f); // Get a random x value in the range of -2 to 2
    transform.position = new Vector3(randomX, 0f, 0f); // Respawn the object at a random x position and y position of 0
}
}
