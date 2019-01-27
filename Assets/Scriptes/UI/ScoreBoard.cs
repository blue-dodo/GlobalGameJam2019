using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private Canvas scoreBoardCanvas;

    public void OnRaise(bool gameFineshed)
    {
        if(gameFineshed)
        {
            uiCanvas.enabled = false;
            scoreBoardCanvas.enabled = true;
        }
        else
        {
            uiCanvas.enabled = true;
            scoreBoardCanvas.enabled = false;
        }
    }
}
