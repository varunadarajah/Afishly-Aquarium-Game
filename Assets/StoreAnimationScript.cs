using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAnimationScript : MonoBehaviour
{
    public GameObject parentObject;
    private void OnMouseDown() { 
        Animator[] childAnimators = parentObject.GetComponentsInChildren<Animator>(true);
            foreach (Animator childAnimator in childAnimators)
            {
                childAnimator.enabled = true;
            }

    }
}
