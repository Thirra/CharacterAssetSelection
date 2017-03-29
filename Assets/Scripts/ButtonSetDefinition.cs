using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Values of one button correlate to the values of another button

[System.Serializable]
public class ButtonSetDefinition
{
    #region Mid Button Parameters
    [Range(0, 900)]
    public float midXPosition;

    [Range(0, 500)]
    public float midYPosition;

    [Range(0, 300)]
    public float midWidth;

    [Range(0, 200)]
    public float midHeight;

    private string assetName;

    [SerializeField]
    private GUIStyle midButtonStyle;
    #endregion

    #region Side Button Parameters
    [Range(0, 900)]
    public float sideButtonWidth;

    [Range(0, 500)]
    public float sideButtonHeight;

    [Range(0, 100)]
    public float range;

    [SerializeField]
    private Texture leftArrow;

    [SerializeField]
    private Texture rightArrow;

    [SerializeField]
    private GUIStyle sideButtonStyle;
    #endregion

    #region Label Parameters
    [SerializeField]
    private string labelName;

    [SerializeField]
    private bool labelOnTop = true;

    [SerializeField]
    private GUIStyle labelStyle;

    private float labelHeight;
    #endregion

    #region Arrays
    [SerializeField]
    private string[] assetNumber;

    [SerializeField]
    private Texture2D[] assetTextures;
    #endregion

    #region Asset Texture Parameters
    [Range(0, 900)]
    public float textureXPosition;

    [Range(0, 500)]
    public float textureYPosition;

    [Range(0, 1000)]
    public float textureWidth;

    [Range(0, 1000)]
    public float textureHeight;

    private Texture2D texture;
    #endregion

    #region Indices and Ints (Private variables)
    private int currentIndex = 0;
    private int textureIndex;

    private int assetLength;
    #endregion

    public void Draw()
    {
        //Length of the assetTexture array equals the length of the assetNumber array
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
        //Making the index of both arrays equal 
        assetName = assetNumber[currentIndex];
        texture = assetTextures[currentIndex];

        //Setting default backgrounds - Preventative measure for errors
        if (midButtonStyle.normal.background == null)
        {
            midButtonStyle = GUI.skin.box;
        }

        if (sideButtonStyle.normal.background == null)
        {
            sideButtonStyle = GUI.skin.box;
        }

        //Setting default text - Another preventative measure
        if (labelStyle.font == null)
        {
            labelStyle.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        }

        //Getting the width of a label created
        int labelNameLength = labelName.Length * sizeof(char);

        //Setting functionality for labels on top and on bottom
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
        if (GUI.Button(new Rect(midXPosition, midYPosition, midWidth, midHeight), assetName, midButtonStyle))
        {
            //Do nothing -> could be a box instead of a button
        }

        //Left Button
        if (GUI.Button(new Rect((-sideButtonWidth - range + midXPosition), (midYPosition + (midHeight/2 - sideButtonHeight/2)), sideButtonWidth, sideButtonHeight), leftArrow, sideButtonStyle))
        {
            currentIndex -= 1;
        }

        //Right Button
        if (GUI.Button(new Rect((midWidth + range + midXPosition), (midYPosition + (midHeight/2 - sideButtonHeight/2)), sideButtonWidth, sideButtonHeight), rightArrow, sideButtonStyle))
        {
            currentIndex += 1;
        }

        //Texture that correlates with a button
        GUI.Box(new Rect(textureXPosition, textureYPosition, textureWidth, textureHeight), texture);
    }
}
