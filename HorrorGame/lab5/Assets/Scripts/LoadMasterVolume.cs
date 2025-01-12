using UnityEngine;

public class LoadMasterVolume : MonoBehaviour
{
    private float currentVolume = 1f;

    private void Start()
    {
        // Wczytaj warto�� g�o�no�ci z PlayerPrefs
        currentVolume = PlayerPrefs.GetFloat("Volume", 1f);

        // Zastosuj g�o�no�� w tej scenie
        ApplyVolumeInScene();
    }

    void ApplyVolumeInScene()
    {
        // Zastosowanie g�o�no�ci na wszystkich AudioSource w tej scenie
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            // Zastosuj g�o�no�� na ka�dym AudioSource
            audioSource.volume = audioSource.volume * currentVolume;
        }
    }
}
