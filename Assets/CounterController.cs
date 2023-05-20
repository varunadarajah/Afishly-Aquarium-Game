using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    public LevelUpClamScript levelUpClam;
    public UnlockMusselScript unlockMussel;
    public UnlockOysterScript unlockOyster;

    // Start is called before the first frame update
    void Start()
    {
        levelUpClam = GameObject.FindObjectOfType<LevelUpClamScript>();

        unlockMussel = GameObject.FindObjectOfType<UnlockMusselScript>();

        unlockOyster = GameObject.FindObjectOfType<UnlockOysterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        int clamCount = levelUpClam.clickCount;
        int musselCount = unlockMussel.clickCount;
        int oysterCount = unlockOyster.clickCount;

        if (clamCount == 1)
        {
            unlockMussel.clickCount = 0;
            unlockOyster.clickCount = 0;
        }
        else if (musselCount == 1)
        {
            levelUpClam.clickCount = 0;
            unlockOyster.clickCount = 0;
        }
        else if (oysterCount == 1)
        {
            levelUpClam.clickCount = 0;
            unlockMussel.clickCount = 0;
        }
    }
}
