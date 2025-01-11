using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AnimationManager : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float waitTime = 3f; // Time to wait after the animation ends (in seconds)
    public string animationName = "YourAnimationName"; // Name of the animation to play

    private void Start()
    {
        // Start the animation
        PlayAnimation();
    }

    void PlayAnimation()
    {
        // Play the specified animation
        animator.Play(animationName);

        // Start the coroutine to wait after the animation ends
        StartCoroutine(WaitAfterAnimation());
    }

    IEnumerator WaitAfterAnimation()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(waitTime);

        // Optionally: Add any code you want to run after the waiting time
        // For example, load the next scene or enable other objects
        Debug.Log("Waiting time ended. Proceeding with next action.");

        // Example: Load the next scene (if you want to load a new scene after waiting)
        // SceneManager.LoadScene("NextSceneName");

        // If you want to enable something after the wait, you can do that too:
        // Example: Enable a UI element after waiting
        // someUIElement.SetActive(true);
    }
}
