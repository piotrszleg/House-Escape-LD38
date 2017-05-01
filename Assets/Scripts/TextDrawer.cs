using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class TextDrawer : MonoBehaviour
{

    string[] toDisplay;
    Text display;
    public float speed = 10f;
    public float forgetTime = 0.5f;
    public bool drawing = false;

    // Use this for initialization
    void Start()
    {
        display = GetComponent<Text>();
    }

    public void Write(string text)
    {
        toDisplay = new string[] { text };
        StartCoroutine(DisplayText(toDisplay));
    }
    public void Write(string[] text)
    {
        toDisplay = text;
        StartCoroutine(DisplayText(toDisplay));
    }

    IEnumerator DisplayText(string[] text)
    {
        if (drawing)
        {
            yield break;
        }
        drawing = true;
        for (int i=0; i < text.Length; i++)
        {
            display.text = "";
            for (int j = 0; j < text[i].Length; j++)
            {
                if (Input.GetMouseButton(0) && j>3)
                {
                    //Stop writing text.
                    display.text = "";
                    drawing = false;
                    yield break;
                }
                display.text += text[i][j];
                yield return new WaitForSeconds(1/speed);
            }
            yield return new WaitForSeconds(forgetTime);
        }
        display.text = "";
        drawing = false;
    }
}