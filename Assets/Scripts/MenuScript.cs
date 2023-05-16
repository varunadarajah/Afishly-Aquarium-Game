using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public GameObject objectToMove;
    public float targetYPosition = -1f;
    public float slideDuration = 1f;

    private bool isMoving = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            StartCoroutine(SlideObjectToTargetPosition());
        }
    }

    private IEnumerator SlideObjectToTargetPosition()
    {
        isMoving = true;

        Vector3 startPosition = objectToMove.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYPosition, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float t = elapsedTime / slideDuration;
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.transform.position = targetPosition;
        isMoving = false;
}


}
