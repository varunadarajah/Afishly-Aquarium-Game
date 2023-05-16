using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControllerScript : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject editMode; 
    public GameObject editModeScreen;

    private void Update() {
      if (editMode.activeSelf && editModeScreen.activeSelf) {
        Collider2D[] childColliders = parentObject.GetComponentsInChildren<Collider2D>(true);
        foreach (Collider2D childCollider in childColliders)
        {
          childCollider.enabled = true;
        } 

        Animator[] childAnimators = parentObject.GetComponentsInChildren<Animator>(true);
            foreach (Animator childAnimator in childAnimators)
            {
                childAnimator.enabled = false;
                childAnimator.Play(childAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);
                childAnimator.Update(0f);
            }
    }
}
}
