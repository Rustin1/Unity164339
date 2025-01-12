using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public TextMeshProUGUI winLose;

    public void Awake()
    {
        if (LoadLvl.GetWin()) // U¿ywamy GetWin() do sprawdzenia wyniku gry
        {
            winLose.text = "You win";
        }
        else
        {
            winLose.text = "You lost";
        }
    }
}