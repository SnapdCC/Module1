using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiEvents : MonoBehaviour
{
    public void ClickButtonA ()
    {
        Debug.Log("Boop");
    }

    public void TextUpdate (string text)
    {
        Debug.Log("Text Changed: " + text);
    }
}
