using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int playerScore;
    public int playerHealth;

    // Klucz do przechowywania danych w PlayerPrefs w formacie JSON
    private const string PlayerDataKey = "PlayerData";

    // Funkcja do za³adowania danych z PlayerPrefs jako JSON
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(PlayerDataKey))
        {
            string jsonData = PlayerPrefs.GetString(PlayerDataKey);
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
        else
        {
            // Ustaw domyœlne wartoœci, jeœli dane nie istniej¹
            playerName = "DefaultName";
            playerScore = 0;
            playerHealth = 100;
        }
    }

    // Funkcja do zapisania danych do PlayerPrefs jako JSON
    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerDataKey, jsonData);
        PlayerPrefs.Save(); // Zapisz wszystkie zmiany w PlayerPrefs
    }
}
