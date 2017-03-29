using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ButtonCreator : MonoBehaviour
{
    [SerializeField]
    ButtonSetDefinition[] buttons;

    // ------- TEXTURE VALUES ------- //
    [Range(0, 900)]
    public float mainTextureXPosition;

    [Range(0, 500)]
    public float mainTextureYPosition;

    [Range(0, 1000)]
    public float mainTextureWidth;

    [Range(0, 1000)]
    public float mainTextureHeight;

    public Texture2D mainTexture;
    // ------------------------------ //

    void OnGUI()
    {
        GUI.Box(new Rect(mainTextureXPosition, mainTextureYPosition, mainTextureWidth, mainTextureHeight), mainTexture);

        foreach (ButtonSetDefinition button in buttons)
        {
            button.Draw();
        }
    }
}
