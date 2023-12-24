using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Riddles : MonoBehaviour
{
    public string riddle;
    public TextMeshProUGUI uiRiddleText;

    // public bool displayRiddle = false;

    public void SetRiddle()
    {
        uiRiddleText.text = riddle;
    }

    public void ResetRiddle()
    {
        uiRiddleText.text = "";
    }
}
