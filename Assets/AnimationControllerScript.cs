using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    public GameObject plantParentObject;

    public GameObject EditModeScreen;
    public GameObject fish;

    private void Update() 
    {
    if (!EditModeScreen.activeSelf)
    {
        Animator[] childAnimators = plantParentObject.GetComponentsInChildren<Animator>(true);
            foreach (Animator childAnimator in childAnimators)
            {
                childAnimator.enabled = true;
            }

            fish.SetActive(true);
    } else {
        fish.SetActive(false);
    }
    }
}
