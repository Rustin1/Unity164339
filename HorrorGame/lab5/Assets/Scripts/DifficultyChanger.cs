using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    private TMP_Dropdown difficultyDropdown;

    void Start()
    {
        // Pobierz referencj� do komponentu Dropdown
        difficultyDropdown = GetComponent<TMP_Dropdown>();
        difficultyDropdown.ClearOptions();

        // Lista opcji trudno�ci
        List<string> options = new List<string> { "Easy", "Normal", "Hard", "Nightmare" };

        // Dodaj opcje do Dropdown
        difficultyDropdown.AddOptions(options);

        // Dodaj nas�uchiwacz do obs�ugi zmiany trudno�ci
        difficultyDropdown.onValueChanged.AddListener(ChangeDifficulty);

        // Ustaw domy�ln� trudno�� (np. Normalny)
        int savedDifficulty = PlayerPrefs.GetInt("Difficulty", 1);  // Domy�lnie Normalny, je�li brak zapisanych danych
        difficultyDropdown.value = savedDifficulty;
        difficultyDropdown.RefreshShownValue();
    }

    // Zmiana trudno�ci po wybraniu nowej opcji
    public void ChangeDifficulty(int index)
    {
        // Zapisz wybran� trudno�� w PlayerPrefs
        PlayerPrefs.SetInt("Difficulty", index);
    }
}
