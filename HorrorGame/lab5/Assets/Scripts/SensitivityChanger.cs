using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensitivityChangerWithText : MonoBehaviour
{
    public Slider sensitivitySlider; // Referencja do suwaka
    public TextMeshProUGUI sensitivityText; // Referencja do komponentu TextMeshPro
    private LookAround lookAroundScript; // Referencja do skryptu LookAround, aby zmieniaæ czu³oœæ

    private const string sensitivityKey = "Sensitivity"; // Klucz do przechowywania czu³oœci w PlayerPrefs

    void Start()
    {
        // Sprawdzenie, czy w PlayerPrefs jest ju¿ zapisana czu³oœæ, jeœli nie, ustawienie wartoœci domyœlnej
        float savedSensitivity = PlayerPrefs.GetFloat(sensitivityKey, 150f); // Domyœlna wartoœæ 150f, jeœli brak zapisu

        // Ustawienie pocz¹tkowej wartoœci slidera i tekstu
        if (sensitivitySlider != null && sensitivityText != null)
        {
            sensitivitySlider.value = savedSensitivity; // Ustawienie wartoœci suwaka na odczytan¹ z PlayerPrefs
            sensitivityText.text = sensitivitySlider.value.ToString("F2"); // Ustawienie tekstu na wartoœæ suwaka
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity); // Nas³uchiwanie zmiany suwaka
        }

        // Ustawienie czu³oœci w skrypcie LookAround
        if (lookAroundScript != null)
        {
            lookAroundScript.SetSensitivity(savedSensitivity);
        }
    }

    // Funkcja zmieniaj¹ca czu³oœæ oraz tekst na podstawie wartoœci suwaka
    public void UpdateSensitivity(float newSensitivity)
    {
        // Zaktualizowanie czu³oœci w skrypcie LookAround
        if (lookAroundScript != null)
        {
            lookAroundScript.SetSensitivity(newSensitivity);
        }

        // Zaktualizowanie tekstu w TextMeshPro na wartoœæ suwaka
        if (sensitivityText != null)
        {
            sensitivityText.text = newSensitivity.ToString("F2"); // Formatowanie na dwie liczby po przecinku
        }

        // Zapisanie nowej czu³oœci w PlayerPrefs
        PlayerPrefs.SetFloat(sensitivityKey, newSensitivity);
        PlayerPrefs.Save(); // Zapisywanie danych w PlayerPrefs
    }
}
