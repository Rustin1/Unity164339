using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    bool win = LoadLvl.getWin();
    public Text winLose;

    private void Awake()
    {
        if (win)
            winLose.text = "Congratulations, you win";
        else
            winLose.text = "Gameover, you lost";
    }

}
