using UnityEngine;
using System.Collections;

public class ExitButtonScript : MonoBehaviour
{
    public GameObject objectToMoveExit;
    public float targetYPosition = -9f;
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

        Vector3 startPosition = objectToMoveExit.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYPosition, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float t = elapsedTime / slideDuration;
            objectToMoveExit.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMoveExit.transform.position = targetPosition;
        isMoving = false;
    }
}
