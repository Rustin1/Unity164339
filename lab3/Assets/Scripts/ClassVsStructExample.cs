using UnityEngine;

public class ClassVsStructExample : MonoBehaviour
{
    // Class example
    public class PointClass
    {
        public float x;
        public float y;

        public PointClass(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // Struct example
    public struct PointStruct
    {
        public float x;
        public float y;

        public PointStruct(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    void Start()
    {
        // Demonstrating class behavior
        PointClass pointClassA = new PointClass(1f, 1f);
        PointClass pointClassB = pointClassA; // Reference copy
        pointClassB.x = 2f;
        Debug.Log("PointClass A: x = " + pointClassA.x + ", y = " + pointClassA.y); // Outputs: x = 2, y = 1
        Debug.Log("PointClass B: x = " + pointClassB.x + ", y = " + pointClassB.y); // Outputs: x = 2, y = 1

        // Demonstrating struct behavior
        PointStruct pointStructA = new PointStruct(1f, 1f);
        PointStruct pointStructB = pointStructA; // Value copy
        pointStructB.x = 2f;
        Debug.Log("PointStruct A: x = " + pointStructA.x + ", y = " + pointStructA.y); // Outputs: x = 1, y = 1
        Debug.Log("PointStruct B: x = " + pointStructB.x + ", y = " + pointStructB.y); // Outputs: x = 2, y = 1
    }
}
