using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    public GameObject parentObject;

    public GameObject EditModeScreen;

    private void Update() 
    {
    if (!EditModeScreen.activeSelf)
    {
    Animator[] childAnimators = parentObject.GetComponentsInChildren<Animator>(true);
            foreach (Animator childAnimator in childAnimators)
            {
                childAnimator.enabled = true;
            }
    }
    }
}
