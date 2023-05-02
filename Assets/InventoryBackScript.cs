using UnityEngine;
using System.Collections;

public class InventoryBackScript : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject MoveTurlteBox;
    public float targetYPosition = -1f;
    public float targetYTurtle = -1f; 
    public float slideDuration = 1f;
    public GameObject toggleTurtleUpArrow;
    public GameObject toggleTurtleDownArrow;
    public GameObject closeTurtleBox;
    public GameObject toggleVanillaUpArrow;
    public GameObject toggleVanillaDownArrow;
    public GameObject closeVanillaBox;

    private bool isMoving = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            StartCoroutine(SlideObjectToTargetPosition());
            StartCoroutine(MoveTurtleBoxToTargetPosition());

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
        toggleArrow();
    }

     private IEnumerator MoveTurtleBoxToTargetPosition()
    {
        isMoving = true;

        Vector3 startPosition = MoveTurlteBox.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYTurtle, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float t = elapsedTime / slideDuration;
            MoveTurlteBox.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        MoveTurlteBox.transform.position = targetPosition;
        isMoving = false;
    }

     void toggleArrow()
    {
        if (closeTurtleBox != null)
        {
            closeTurtleBox.SetActive(false);
        }
        if (toggleTurtleUpArrow != null)
        {
            toggleTurtleUpArrow.SetActive(true);
        }
        if (toggleTurtleDownArrow != null)
        {
            toggleTurtleDownArrow.SetActive(false);
        }
         if (closeVanillaBox != null)
        {
            closeVanillaBox.SetActive(false);
        }
        if (toggleVanillaUpArrow != null)
        {
            toggleVanillaUpArrow.SetActive(true);
        }
        if (toggleVanillaDownArrow != null)
        {
            toggleVanillaDownArrow.SetActive(false);
        }
}
}
