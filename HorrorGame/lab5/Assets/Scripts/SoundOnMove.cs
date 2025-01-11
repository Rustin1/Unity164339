using UnityEngine;
using System.Collections; // To use coroutines

public class PlaySoundOnMove : MonoBehaviour
{
    // The AudioSource component that will play the sound
    public AudioSource audioSource;

    // The minimum distance the object must move before the sound is played
    public float minMoveDistance = 0.1f;

    // The position of the object in the previous frame
    private Vector3 previousPosition;

    // A flag to check if the sound is currently playing
    private bool isPlaying = false;

    // A flag to check if coroutine is already running
    private bool isCoroutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the object
        previousPosition = transform.position;

        // Ensure audio is stopped at the start
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance the object has moved since the last frame
        float moveDistance = Vector3.Distance(transform.position, previousPosition);

        // If the object has moved more than the minimum distance
        if (moveDistance >= minMoveDistance)
        {
            // Start playing sound with a delay if not already playing and not in coroutine
            if (!isPlaying && !isCoroutineRunning)
            {
                StartCoroutine(PlaySoundWithDelay());
            }
        }
        else
        {
            // If the object stops moving for a while, stop the sound
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;  // Set the flag to indicate sound is not playing
            }
        }

        // Store the current position of the object for the next frame
        previousPosition = transform.position;
    }

    // Coroutine to handle the delay before playing the sound
    private IEnumerator PlaySoundWithDelay()
    {
        isCoroutineRunning = true;

        // Wait for half a second before playing the sound
        yield return new WaitForSeconds(0.5f);

        // After delay, play the sound
        audioSource.Play();
        isPlaying = true;

        isCoroutineRunning = false;
    }
}
