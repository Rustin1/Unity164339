using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    public void SettingsPanelActivate()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
