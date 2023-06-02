using UnityEngine;

public class ColorWhite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Shader whiteShader; // Reference to the white sprite shader

    private void Start()
    {
        // Get the reference to the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Create a new material with the white sprite shader
        Material whiteMaterial = new Material(whiteShader);

        // Assign the new material to the sprite renderer
        spriteRenderer.material = whiteMaterial;
    }
}
