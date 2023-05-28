using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOneButtons : MonoBehaviour
{
    public PuzzleOne puzzleReference;
    public int buttonNumber;
    public string buttonName;
    public Sprite normalColor;
public void Clicked()
    {
        if (puzzleReference.canClick)
        {
            print("Pode clicar");
            StartCoroutine(puzzleReference.SelectButton(buttonNumber));
        }
    }
    public void Update()
    {
        if(Input.GetAxis(buttonName) > 0)
        {
            Clicked();
        }
    }
    public Sprite NormalColor()
    {
        return normalColor;
    }
}
