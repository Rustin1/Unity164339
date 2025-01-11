using UnityEngine;

public class LoadMasterVolume : MonoBehaviour
{
    private float currentVolume = 1f;

    private void Start()
    {
        // Wczytaj wartoœæ g³oœnoœci z PlayerPrefs
        currentVolume = PlayerPrefs.GetFloat("Volume", 1f);

        // Zastosuj g³oœnoœæ w tej scenie
        ApplyVolumeInScene();
    }

    void ApplyVolumeInScene()
    {
        // Zastosowanie g³oœnoœci na wszystkich AudioSource w tej scenie
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            // Zastosuj g³oœnoœæ na ka¿dym AudioSource
            audioSource.volume = audioSource.volume * currentVolume;
        }
    }
}
