using UnityEngine;

public class ColorPickerManager : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("C");
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Texture2D texture = renderer.material.mainTexture as Texture2D;
                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= texture.width;
                    pixelUV.y *= texture.height;

                    Color pixelColor = texture.GetPixel((int)pixelUV.x, (int)pixelUV.y);
                    Debug.Log("Pixel Color: " + pixelColor);
                }
            }
        }
    }
}
