using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    private TMP_Dropdown difficultyDropdown;

    void Start()
    {
        // Pobierz referencjê do komponentu Dropdown
        difficultyDropdown = GetComponent<TMP_Dropdown>();
        difficultyDropdown.ClearOptions();

        // Lista opcji trudnoœci
        List<string> options = new List<string> { "Easy", "Normal", "Hard", "Nightmare" };

        // Dodaj opcje do Dropdown
        difficultyDropdown.AddOptions(options);

        // Dodaj nas³uchiwacz do obs³ugi zmiany trudnoœci
        difficultyDropdown.onValueChanged.AddListener(ChangeDifficulty);

        // Ustaw domyœln¹ trudnoœæ (np. Normalny)
        int savedDifficulty = PlayerPrefs.GetInt("Difficulty", 1);  // Domyœlnie Normalny, jeœli brak zapisanych danych
        difficultyDropdown.value = savedDifficulty;
        difficultyDropdown.RefreshShownValue();
    }

    // Zmiana trudnoœci po wybraniu nowej opcji
    public void ChangeDifficulty(int index)
    {
        // Zapisz wybran¹ trudnoœæ w PlayerPrefs
        PlayerPrefs.SetInt("Difficulty", index);
    }
}
