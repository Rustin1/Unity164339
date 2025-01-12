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
        // Zapewnienie, ¿e jest tylko jedna instancja skryptu
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ten obiekt nie bêdzie usuwany przy zmianie sceny
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
        // Wczytaj wartoœæ g³oœnoœci z PlayerPrefs
        if (PlayerPrefs.HasKey("Volume"))
        {
            currentVolume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            currentVolume = 1f; // Domyœlna wartoœæ
        }

        // Ustaw tekst g³oœnoœci
        if (volumeText != null)
        {
            volumeText.text = (currentVolume * 100).ToString("F0") + "%";
        }

        // Ustaw suwak, jeœli jest dostêpny
        if (volumeSlider != null)
        {
            volumeSlider.value = currentVolume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        // Zastosuj g³oœnoœæ w tej scenie
        ApplyVolumeInScene();
    }

    // Funkcja do zmiany g³oœnoœci
    void OnVolumeChanged(float value)
    {
        // Zapisz g³oœnoœæ do PlayerPrefs
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();

        // Zaktualizuj g³oœnoœæ
        currentVolume = value;
        volumeText.text = (value * 100).ToString("F0") + "%";

        ApplyVolumeInScene();  // Zastosuj g³oœnoœæ na wszystkich AudioSource
    }

    // Funkcja do zastosowania g³oœnoœci na wszystkich AudioSource w scenie
    void ApplyVolumeInScene()
    {
        // Pobierz wszystkie AudioSource w scenie
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (!initialVolumes.ContainsKey(audioSource))
            {
                initialVolumes[audioSource] = audioSource.volume; // Zapisz pocz¹tkow¹ wartoœæ
            }

            // Ustaw now¹ g³oœnoœæ na podstawie pocz¹tkowej wartoœci
            audioSource.volume = initialVolumes[audioSource] * currentVolume;
        }
    }

    // Funkcja wywo³ywana po za³adowaniu sceny
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Zastosowanie g³oœnoœci w tej scenie
        ApplyVolumeInScene();
    }

    // Usuwanie nas³uchiwacza przy zniszczeniu obiektu
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
