using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public string objectNameToCompare = "RockCollider";
    public bool IsTouchingOtherObject()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
    foreach (Collider2D collider in colliders)
    {
    if (collider.gameObject.name == objectNameToCompare)
        {
            return true;
        }
    }
    return false;
}
}
