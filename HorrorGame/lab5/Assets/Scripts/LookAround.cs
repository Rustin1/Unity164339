using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform orientation;

    public float sensitivity = 150f;
    float xRotation;
    float yRotation;

    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        // Odczytanie czu³oœci z PlayerPrefs (jeœli jest zapisana) TYLKO raz
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 150f); // Odczytujemy tylko raz przy starcie
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

 
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yRotation += mouseXMove;

        xRotation -= mouseYMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    // Ta funkcja mo¿e byæ u¿ywana do zmiany czu³oœci z zewn¹trz

    // Ta metoda zmienia czu³oœæ
    public void SetSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
        Debug.Log("Sensitivity set to: " + sensitivity);
    }
}
