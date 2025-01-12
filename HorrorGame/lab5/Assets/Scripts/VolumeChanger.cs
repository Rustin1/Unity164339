using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager Instance;

    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    private float currentVolume = 1f;
    private Dictionary<AudioSource, float> initialVolumes = new Dictionary<AudioSource, float>();

    private void Awake()
    {
        // Zapewnienie, �e jest tylko jedna instancja skryptu
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ten obiekt nie b�dzie usuwany przy zmianie sceny
        }
        else
        {
            Destroy(gameObject);
        }

        // Rejestracja metody do wydarzenia 'sceneLoaded'
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Wczytaj warto�� g�o�no�ci z PlayerPrefs
        if (PlayerPrefs.HasKey("Volume"))
        {
            currentVolume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            currentVolume = 1f; // Domy�lna warto��
        }

        // Ustaw tekst g�o�no�ci
        if (volumeText != null)
        {
            volumeText.text = (currentVolume * 100).ToString("F0") + "%";
        }

        // Ustaw suwak, je�li jest dost�pny
        if (volumeSlider != null)
        {
            volumeSlider.value = currentVolume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        // Zastosuj g�o�no�� w tej scenie
        ApplyVolumeInScene();
    }

    // Funkcja do zmiany g�o�no�ci
    void OnVolumeChanged(float value)
    {
        // Zapisz g�o�no�� do PlayerPrefs
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();

        // Zaktualizuj g�o�no��
        currentVolume = value;
        volumeText.text = (value * 100).ToString("F0") + "%";

        ApplyVolumeInScene();  // Zastosuj g�o�no�� na wszystkich AudioSource
    }

    // Funkcja do zastosowania g�o�no�ci na wszystkich AudioSource w scenie
    void ApplyVolumeInScene()
    {
        // Pobierz wszystkie AudioSource w scenie
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (!initialVolumes.ContainsKey(audioSource))
            {
                initialVolumes[audioSource] = audioSource.volume; // Zapisz pocz�tkow� warto��
            }

            // Ustaw now� g�o�no�� na podstawie pocz�tkowej warto�ci
            audioSource.volume = initialVolumes[audioSource] * currentVolume;
        }
    }

    // Funkcja wywo�ywana po za�adowaniu sceny
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Zastosowanie g�o�no�ci w tej scenie
        ApplyVolumeInScene();
    }

    // Usuwanie nas�uchiwacza przy zniszczeniu obiektu
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
