using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaturationBrightnessPicker : MonoBehaviour
{
    [SerializeField]
    RectTransform texture;
    [SerializeField]
    SpriteRenderer combinedColor;
    [SerializeField]
    Texture2D referencedSprite;

    public void onClickPickerColor()
    {
        setColor();
    }

    private void setColor()
    {
        Vector3 imagePos = texture.position;
        float posX = Input.mousePosition.x - imagePos.x;
        float posY = Input.mousePosition.y - imagePos.y;

        int localPosX = (int)(posX * (referencedSprite.width / texture.rect.width));
        int localPosY = (int)(posY * (referencedSprite.height / texture.rect.height));

        Color c = referencedSprite.GetPixel(localPosX, localPosY);
        setActualColor(c);
    }

    void setActualColor(Color c) 
    {
        combinedColor.color = c;
    }
}
