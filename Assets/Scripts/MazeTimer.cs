using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MazeTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject object1; // Reference to the first object
    public GameObject object2; // Reference to the second object
    public GameObject object3;
    public Canvas resultCanvas;

    private float timer = 0f;
    private bool timerStarted = false;
    private bool characterMoving = false;

    private void Start()
    {
        // Initialize the timer text
        UpdateTimerText();

        // Hide the result canvas initially
        resultCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (characterMoving && !timerStarted)
        {
            // Start the timer when the character starts moving
            StartTimer();
        }

        if (timerStarted)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Update the timer text
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        // Update the timer text display
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2"); // Displaying timer with two decimal places
        }
    }

    public void StartTimerOnCharacterMove()
    {
        // Set the flag to indicate that the character is moving
        characterMoving = true;
    }

    private void StartTimer()
    {
        // Start the timer
        timerStarted = true;
    }

    public void EndTimer()
    {
        // Stop the timer
        timerStarted = false;

        // Reset the flag to indicate that the character is not moving
        characterMoving = false;

        // Display result text
        timerText.text = "Completion Time: " + timer.ToString("F2") + "s";

        // Show the result canvas
        resultCanvas.gameObject.SetActive(true);

        // Clear Scene
        Destroy(object1);
        Destroy(object2);
        Destroy(object3);
    }

    public void ReturnToMainMenu()
    {
        // You can add more logic here if needed (e.g., save data, reset variables)

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
