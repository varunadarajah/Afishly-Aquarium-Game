using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MolluskData
{
    public int clamLevel = 0;
    public int musselLevel = 0;
    public int oysterLevel = 0;

    public MolluskData(LevelUpClamScript data)
    {
        clamLevel = data.currentLevel;
        musselLevel = data.unlockMussel.currentLevel;
        oysterLevel = data.unlockOyster.currentLevel;
    }
}
