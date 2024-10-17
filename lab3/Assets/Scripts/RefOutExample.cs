using UnityEngine;

public class RefOutExample : MonoBehaviour
{
    void Start()
    {
        // Using ref argument
        int refValue = 10;
        Debug.Log("Initial refValue: " + refValue);
        ModifyValueUsingRef(ref refValue);
        Debug.Log("Modified refValue: " + refValue); // Outputs: 20

        // Using out argument
        int outValue;
        ModifyValueUsingOut(out outValue);
        Debug.Log("Modified outValue: " + outValue); // Outputs: 30

        // Without ref or out
        int normalValue = 10;
        Debug.Log("Initial normalValue: " + normalValue);
        ModifyValueWithoutRefOrOut(normalValue);
        Debug.Log("Modified normalValue: " + normalValue); // Outputs: 10 (no change)
    }

    void ModifyValueUsingRef(ref int value)
    {
        // The ref keyword allows us to modify the original value
        value *= 2;
    }

    void ModifyValueUsingOut(out int value)
    {
        // The out keyword requires the method to assign a value before the method returns
        value = 30;
    }

    void ModifyValueWithoutRefOrOut(int value)
    {
        // Without ref or out, this is just a copy of the original value
        value *= 2;
    }
}
