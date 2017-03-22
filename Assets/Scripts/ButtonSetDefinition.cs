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

    // --------- LEFT BUTTON -------- //
    [Range(0, 1000)]
    public float leftXPosition;
    // ------------------------------ //


    // -------- RIGHT BUTTON -------- //
    [Range(0, 1000)]
    public float rightXPosition;
    // ------------------------------ //


    // ----- SIDE BUTTON VALUES ----- //
    [Range(0, 900)]
    public float sideButtonWidth;

    [Range(0, 500)]
    public float sideButtonHeight;
    // ------------------------------ //

    [SerializeField]
    private string assetName;

    public GUIStyle style;

	public void Draw()
    {
        if (style.normal.background == null)
        {
            style = "box";
        }

        //Main Button (Doesn't necessarily have to be in the middle)
        if (GUI.Button(new Rect(midXPosition, midYPosition, midWidth, midHeight), assetName, style))
        {
            //Do something
        }

        ////Left Button
        //if (GUI.Button(new Rect(leftXPosition, midYPosition, sideButtonWidth, sideButtonHeight), assetName, style))
        //{
        //    //Do something
        //}

        ////Right Button
        //if (GUI.Button(new Rect(rightXPosition, midYPosition, sideButtonWidth, sideButtonHeight), assetName, style))
        //{
        //    //Do something
        //}
    }
}
