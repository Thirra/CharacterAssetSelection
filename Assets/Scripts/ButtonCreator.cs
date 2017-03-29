using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ButtonCreator : MonoBehaviour
{
    [SerializeField]
    ButtonSetDefinition[] buttons;

    #region Texture Values
    [Range(0, 900)]
    public float mainTextureXPosition;

    [Range(0, 500)]
    public float mainTextureYPosition;

    [Range(0, 1000)]
    public float mainTextureWidth;

    [Range(0, 1000)]
    public float mainTextureHeight;

    public Texture2D mainTexture;
    #endregion

    void OnGUI()
    {
        //Draws the main texture 
        GUI.Box(new Rect(mainTextureXPosition, mainTextureYPosition, mainTextureWidth, mainTextureHeight), mainTexture);

        //Draws each of the buttons
        foreach (ButtonSetDefinition button in buttons)
        {
            button.Draw();
        }
    }
}
