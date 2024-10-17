
using UnityEngine;
using System.Collections;

public class YieldExample : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GenerateNumbers());
    }

    IEnumerator GenerateNumbers()
    {
        Debug.Log("Starting number generation...");
        for (int i = 1; i <= 5; i++)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second before continuing
            Debug.Log("Generated number: " + i);
        }
        Debug.Log("Number generation complete.");
    }
}
