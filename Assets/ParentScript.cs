using UnityEngine;

public class ParentScript : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private Transform childTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        childTransform = transform.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    offset = childTransform.position - hit.point;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            childTransform.position = new Vector3(mousePosition.x, mousePosition.y, 0f) + offset;
        }
    }
}
