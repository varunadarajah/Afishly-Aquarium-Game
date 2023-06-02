using UnityEngine;
using System.Collections;

public class PageCloserInventory : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject pageCloser;
    public float targetYPosition = -1f;
    public float slideDuration = 1f;
    public GameObject toggleFishview;
    public GameObject toggleFishBoxPage;

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
        toggleArrow();
    }
void toggleArrow()
    {
     if (toggleFishview != null)
        {
            toggleFishview.SetActive(false);
        }
        if (toggleFishBoxPage != null)
        {
            toggleFishBoxPage.SetActive(true);
        }
        pageCloser.SetActive(false);
    }
}
