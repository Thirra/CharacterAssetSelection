using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonSetDefinition
{
    //Some values may be used in the drawing of other buttons

    // --------- MID BUTTON --------- //
    [Range(0, 900)]
    public float midXPosition;

    [Range(0, 500)]
    public float midYPosition;

    [Range(0, 300)]
    public float midWidth;

    [Range(0, 200)]
    public float midHeight;
    // ------------------------------ //

        //The left and right buttons will be used to change between the assets, so the values may be similar

    // ----- SIDE BUTTON VALUES ----- //
    [Range(0, 900)]
    public float sideButtonWidth;

    [Range(0, 500)]
    public float sideButtonHeight;
    // ------------------------------ //

    [Range(0, 100)]
    public float range;

    [SerializeField]
    private string assetName;

    public GUIStyle style;

    public Texture leftArrow;

    public Texture rightArrow;

    public string labelName;

    public GUIStyle labelStyle;

    public bool labelOnTop = true;

    private float labelHeight;

    [SerializeField]
    private string[] assetNumber;

    int currentIndex = 0;
    int assetLength;

    int textureIndex;

    // ------- TEXTURE VALUES ------- //
    [Range(0, 900)]
    public float textureXPosition;

    [Range(0, 500)]
    public float textureYPosition;

    [Range(0, 1000)]
    public float textureWidth;

    [Range(0, 1000)]
    public float textureHeight;

    private Texture2D texture;
    // ------------------------------ //

    public Texture2D[] assetTextures;

    public void Draw()
    {
        assetLength = assetNumber.Length;

        System.Array.Resize(ref assetTextures, assetNumber.Length);

        //Scrolling through the array
        if (currentIndex < 0)
        {
            currentIndex = assetNumber.Length - 1;
        }
        if (currentIndex >= assetNumber.Length)
        {
            currentIndex = 0;
        }
        assetName = assetNumber[currentIndex];

        texture = assetTextures[currentIndex];

        if (style.normal.background == null)
        {
            style = "box";
        }

        //If there is no font chosen, set it to default
        if (labelStyle.font == null)
        {
            labelStyle.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        }

        int labelNameLength = labelName.Length * sizeof(char);

        if (labelOnTop == true)
        {
            labelHeight = midYPosition - (labelStyle.fontSize + 1);
        }
        else
        {
            labelHeight = midYPosition + midHeight;
        }
        //Label for the main button
        GUI.Label(new Rect((midXPosition + midWidth/2 - (labelNameLength * 1.6f)), labelHeight, midWidth, midHeight), labelName, labelStyle);

        //Main Button (Doesn't necessarily have to be in the middle)
        if (GUI.Button(new Rect(midXPosition, midYPosition, midWidth, midHeight), assetName, style))
        {
            //Do nothing
        }

        //Left Button
        if (GUI.Button(new Rect((-sideButtonWidth - range + midXPosition), (midYPosition + (midHeight/2 - sideButtonHeight/2)), sideButtonWidth, sideButtonHeight), leftArrow, style))
        {
            currentIndex -= 1;
        }

        //Right Button
        if (GUI.Button(new Rect((midWidth + range + midXPosition), (midYPosition + (midHeight/2 - sideButtonHeight/2)), sideButtonWidth, sideButtonHeight), rightArrow, style))
        {
            currentIndex += 1;
        }

        //Texture that correlates with a button
        GUI.Box(new Rect(textureXPosition, textureYPosition, textureWidth, textureHeight), texture);
    }
}
