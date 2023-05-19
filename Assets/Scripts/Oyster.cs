using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyster : MonoBehaviour
{
    public Game game;
    public UnlockOysterScript curr;
    public int pearlPerTap;
    private bool isCooldown = false; // Flag to track cooldown state
    public GameObject objectToToggle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (!isCooldown) // Check if not in cooldown state
        {
            if (curr.currentLevel == 1) {
                pearlPerTap = 100;
            }
            if (curr.currentLevel == 2) {
                pearlPerTap = 250;
            }
            if (curr.currentLevel == 3) {
                pearlPerTap = 500;
            }
            if (curr.currentLevel == 4) {
                pearlPerTap = 1000;
            }
            game.pearls += pearlPerTap;
            ToggleObject();
            StartCoroutine(StartCooldown()); // Start the cooldown coroutine
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true; // Set cooldown state to true
        yield return new WaitForSeconds(60f);
        isCooldown = false; // Set cooldown state to false after 10 seconds
        ToggleObject();
    }

    void ToggleObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf); // Toggle the active state of the other object
        }
    }
}
