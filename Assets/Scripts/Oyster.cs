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

    public AudioSource buttonSFX;

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
            buttonSFX.Play();

            if (curr.currentLevel == 1) {
                pearlPerTap = 1500;
            }
            if (curr.currentLevel == 2) {
                pearlPerTap = 3000;
            }
            if (curr.currentLevel == 3) {
                pearlPerTap = 4500;
            }
            if (curr.currentLevel == 4) {
                pearlPerTap = 6000;
            }
            if (curr.currentLevel == 5) {
                pearlPerTap = 7500;
            }
            if (curr.currentLevel == 6) {
                pearlPerTap = 10500;
            }
            if (curr.currentLevel == 7) {
                pearlPerTap = 14000;
            }
            if (curr.currentLevel == 8) {
                pearlPerTap = 18000;
            }
            if (curr.currentLevel == 9) {
                pearlPerTap = 26000;
            }
            if (curr.currentLevel == 10) {
                pearlPerTap = 36000;
            }
            game.pearls += pearlPerTap;
            ToggleObject();
            StartCoroutine(StartCooldown()); // Start the cooldown coroutine
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true; // Set cooldown state to true
        yield return new WaitForSeconds(1200f);
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
