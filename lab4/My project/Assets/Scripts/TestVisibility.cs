using UnityEngine;

public class TestVisibility : MonoBehaviour
{
    // Public field, visible in the Unity inspector
    public int publicValue = 10;

    // Private field, not visible in the Unity inspector
    private int privateValue = 20;

    // Private field, but visible in the inspector due to the [SerializeField] attribute
    [SerializeField]
    private int serializedPrivateValue = 30;

    // Public field, but hidden in the inspector due to the [HideInInspector] attribute
    [HideInInspector]
    public int hiddenPublicValue = 40;

    void Start()
    {
        Debug.Log("Public Value: " + publicValue);
        Debug.Log("Private Value: " + privateValue);
        Debug.Log("Serialized Private Value: " + serializedPrivateValue);
        Debug.Log("Hidden Public Value: " + hiddenPublicValue);
    }
}