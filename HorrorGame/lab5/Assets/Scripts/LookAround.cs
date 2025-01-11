using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform orientation;

    public float sensitivity = 150f;
    float xRotation;
    float yRotation;

    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        // Odczytanie czu�o�ci z PlayerPrefs (je�li jest zapisana) TYLKO raz
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 150f); // Odczytujemy tylko raz przy starcie
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

 
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yRotation += mouseXMove;

        xRotation -= mouseYMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    // Ta funkcja mo�e by� u�ywana do zmiany czu�o�ci z zewn�trz

    // Ta metoda zmienia czu�o��
    public void SetSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
        Debug.Log("Sensitivity set to: " + sensitivity);
    }
}
