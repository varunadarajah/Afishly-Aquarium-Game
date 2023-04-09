using UnityEngine;

public class MusselScript : MonoBehaviour
{
    public GameObject objectToMove;
    public float targetXPosition = -1f;
    public float targetYPosition = -1f;

    private void OnMouseDown()
    {
        MoveObjectToTargetPosition();
    }

    private void MoveObjectToTargetPosition()
    {
        Vector3 targetPosition = new Vector3(targetXPosition, targetYPosition, objectToMove.transform.position.z);
        objectToMove.transform.position = targetPosition;
    }
}
