using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WeepingAngel : MonoBehaviour
{
    //The AI's Nav Mesh Agent
    public NavMeshAgent ai;

    //The player's Transform
    public Transform player;

    //The AI's Animator component
    private Animator aiAnim;

    //The AI's destination
    Vector3 dest;

    //The player's Camera and the AI's jumpscare Camera
    public Camera playerCam, jumpscareCam;

    //The AI's movement speed
    public float aiSpeed;

    //The distance in which the AI can catch the player from
    public float catchDistance;

    //The amount of seconds it takes for the AI's jumpscare to finish
    public float jumpscareTime;

    public AudioSource jumpscareSound;

    //The scene you load into after dying
    public string sceneAfterDeath;

    //The Update() void, stuff occurs every frame in this void

    private void Start()
    {
        aiAnim = transform.Find("Demon").GetComponent<Animator>();

        // Get the difficulty from PlayerPrefs
        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);  // Default to Normal if no saved data

        // Set aiSpeed based on the selected difficulty
        switch (difficulty)
        {
            case 0: // Easy
                aiSpeed = 6;
                break;
            case 1: // Normal
                aiSpeed = 12;
                break;
            case 2: // Hard
                aiSpeed = 20;
                break;
            case 3: // Nightmare
                aiSpeed = 30;
                break;
        }
    }
    void Update()
    {
        //Calculate the player's Camera's frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);

        //Get the AI's distance from the player
        float distance = Vector3.Distance(transform.position, player.position);

        //If the AI is in the player's Camera's view,
        if (GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds))
        {
            ai.speed = 0; //The AI's speed will equal to 0

            //If the player object is active,
            if (player.gameObject.activeSelf == true)
            {
                aiAnim.speed = 0; //The AI'S animation speed will be set to 0
            }
            ai.SetDestination(transform.position); //The AI's destination will be set to themselves to stop a delay in the movement stopping
        }

        //If the AI isn't in the player's Camera's view,
        if (!GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds))
        {
            ai.speed = aiSpeed; //The AI's speed will equal to the value of aiSpeed
            aiAnim.speed = 1; //The AI's animation speed will be set to 1
            dest = player.position; //dest will equal to the player's position
            ai.destination = dest; //The AI's destination will equal to dest

            //If the distance between the player and the AI is less than or equal to the catchDistance,
            if (distance <= catchDistance)
            {
                jumpscareCam.gameObject.SetActive(true); //The jumpscare camera will be set true
                jumpscareSound.Play();
                aiAnim.SetBool("jumpscare", true);
                player.gameObject.SetActive(false); //The player object will be set false
                StartCoroutine(killPlayer()); //The killPlayer() coroutine will start
            }
        }
    }
    //The killPlayer() coroutine
    IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(jumpscareTime); //After the amount of seconds determined by the jumpscareTime,
        SceneManager.LoadScene(2); //The scene after death will load
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

