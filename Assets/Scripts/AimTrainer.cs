using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AimTrainer : MonoBehaviour
{
    public GameObject Target;
    public Text Score;

    private int score = 0;
    private bool spriteClicked = false;

    private void Start()
    {
        // Call the function to spawn the sprite after a delay
        Invoke("SpawnSprite", 1f);
    }

    private void Update()
    {
        // Check if the sprite is clicked
        if (spriteClicked)
        {
            // Increase the score
            score++;
            Score.text = "Score: " + score;
            Debug.Log("Score " + score);

            // Check if the score reaches 10
            if (!(score < 10))
            {
                // Load the MainMenu scene
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                // Respawn the sprite after a delay
                Invoke("SpawnSprite", 1f);
            }

            // Reset the flag
            spriteClicked = false;
        }
    }

    private void OnMouseDown()
    {
        // Check if the sprite is clicked before it disappears
        if (Target.activeSelf)
        {
            // Set the flag to true
            spriteClicked = true;

            // Deactivate the sprite
            Target.SetActive(false);
        }
    }

    private void SpawnSprite()
    {
        // Randomly set the position of the sprite on the screen
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
        Target.transform.position = randomPosition;

        // Activate the sprite
        Target.SetActive(true);

        // Invoke the function to deactivate the sprite after 3 seconds
        Invoke("DeactivateSprite", 1f);
    }

    private void DeactivateSprite()
    {
        // Deactivate the sprite
        Target.SetActive(false);

        // Respawn the sprite after a delay
        Invoke("SpawnSprite", 1f);
    }
}
