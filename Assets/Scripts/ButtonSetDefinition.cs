using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonSetDefinition
{
    //Some values may be used in the drawing of other buttons

    // --------- MID BUTTON --------- //
    [Range(0, 1000)]
    public float midXPosition;

    [Range(0, 500)]
    public float midYPosition;

    [Range(0, 900)]
    public float midWidth;

    [Range(0, 500)]
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

    [SerializeField]
    private string[] assetNumber;

    int currentIndex = 0;

	public void Draw()
    {

        if (currentIndex < 0)
        {
            currentIndex = assetNumber.Length - 1;
        }
        if (currentIndex >= assetNumber.Length)
        {
            currentIndex = 0;
        }
        assetName = assetNumber[currentIndex];

        if (style.normal.background == null)
        {
            style = "box";
        }

        //Main Button (Doesn't necessarily have to be in the middle)
        if (GUI.Button(new Rect(midXPosition, midYPosition, midWidth, midHeight), assetName, style))
        {
            //Do something
        }

        //Left Button
        if (GUI.Button(new Rect((-sideButtonWidth - range + midXPosition), (midYPosition + (midHeight * 0.2f)), sideButtonWidth, sideButtonHeight), leftArrow, style))
        {
            currentIndex -= 1;
        }

        //Right Button
        if (GUI.Button(new Rect((midWidth + range + midXPosition), (midYPosition + (midHeight * 0.2f)), sideButtonWidth, sideButtonHeight), rightArrow, style))
        {
            currentIndex += 1;
        }
    }
}
