using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ButtonCreator : MonoBehaviour
{
    [SerializeField]
    ButtonSetDefinition[] buttons;

	void onGUI()
    {
        foreach (ButtonSetDefinition button in buttons)
        {
            button.Draw();
        }
    }
}
