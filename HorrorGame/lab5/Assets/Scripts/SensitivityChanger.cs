using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensitivityChangerWithText : MonoBehaviour
{
    public Slider sensitivitySlider; // Referencja do suwaka
    public TextMeshProUGUI sensitivityText; // Referencja do komponentu TextMeshPro
    private LookAround lookAroundScript; // Referencja do skryptu LookAround, aby zmienia� czu�o��

    private const string sensitivityKey = "Sensitivity"; // Klucz do przechowywania czu�o�ci w PlayerPrefs

    void Start()
    {
        // Sprawdzenie, czy w PlayerPrefs jest ju� zapisana czu�o��, je�li nie, ustawienie warto�ci domy�lnej
        float savedSensitivity = PlayerPrefs.GetFloat(sensitivityKey, 150f); // Domy�lna warto�� 150f, je�li brak zapisu

        // Ustawienie pocz�tkowej warto�ci slidera i tekstu
        if (sensitivitySlider != null && sensitivityText != null)
        {
            sensitivitySlider.value = savedSensitivity; // Ustawienie warto�ci suwaka na odczytan� z PlayerPrefs
            sensitivityText.text = sensitivitySlider.value.ToString("F2"); // Ustawienie tekstu na warto�� suwaka
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity); // Nas�uchiwanie zmiany suwaka
        }

        // Ustawienie czu�o�ci w skrypcie LookAround
        if (lookAroundScript != null)
        {
            lookAroundScript.SetSensitivity(savedSensitivity);
        }
    }

    // Funkcja zmieniaj�ca czu�o�� oraz tekst na podstawie warto�ci suwaka
    public void UpdateSensitivity(float newSensitivity)
    {
        // Zaktualizowanie czu�o�ci w skrypcie LookAround
        if (lookAroundScript != null)
        {
            lookAroundScript.SetSensitivity(newSensitivity);
        }

        // Zaktualizowanie tekstu w TextMeshPro na warto�� suwaka
        if (sensitivityText != null)
        {
            sensitivityText.text = newSensitivity.ToString("F2"); // Formatowanie na dwie liczby po przecinku
        }

        // Zapisanie nowej czu�o�ci w PlayerPrefs
        PlayerPrefs.SetFloat(sensitivityKey, newSensitivity);
        PlayerPrefs.Save(); // Zapisywanie danych w PlayerPrefs
    }
}
