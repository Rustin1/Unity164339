using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;

    private void Start()
    {
        // Ładowanie danych na starcie
        playerData.LoadData();
        Debug.Log("Player Name: " + playerData.playerName);
        Debug.Log("Player Score: " + playerData.playerScore);
        Debug.Log("Player Health: " + playerData.playerHealth);
    }

    private void OnApplicationQuit()
    {
        // Zapisz dane przy zamykaniu aplikacji
        playerData.SaveData();
    }

    private void OnDestroy()
    {
        // Zapisz dane przy niszczeniu obiektu (np. zmiana sceny)
        playerData.SaveData();
    }

    // Przykładowa funkcja modyfikująca dane
    public void IncreaseScore(int amount)
    {
        playerData.playerScore += amount;
        Debug.Log("Nowy wynik gracza: " + playerData.playerScore);
    }
}
