using UnityEngine;

public class UnityLifecycleDemo : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake: Called once when the script instance is being loaded.");
    }

    void Start()
    {
        Debug.Log("Start: Called before the first frame update, after all Awake calls.");
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate: Called at a fixed time interval, used for physics-related updates.");
    }

    void Update()
    {
        Debug.Log("Update: Called once per frame, used for regular updates like input handling.");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate: Called once per frame, after all Update calls, used for operations that depend on Update.");
    }
}
