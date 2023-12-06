using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSpriteHandler : MonoBehaviour
{
    public GameObject targetSprite;
    public TextMeshProUGUI scoreText;
    public Canvas resultCanvas; // Reference to the result canvas

    private int score = 0;
    private int totalClicks = 0;
    private int accurateClicks = 0;

    private void Start()
    {
        // Call the function to spawn the first sprite
        SpawnSprite();
    }

    private void Update()
    {
        // Check for mouse button down (left mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            // Increase total clicks
            totalClicks++;

            // Create a ray from the mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Check if the ray hits any collider
            if (hit.collider != null)
            {
                // Check if the collider belongs to the target sprite
                if (hit.collider.gameObject == targetSprite)
                {
                    // Increase the score
                    score++;
                    scoreText.text = "Score: " + score;

                    // Increase accurate clicks
                    accurateClicks++;

                    // Spawn the next sprite immediately
                    SpawnSprite();
                }
            }
        }
    }

    private void SpawnSprite()
    {
        // Randomly set the position of the sprite on the screen
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
        targetSprite.transform.position = randomPosition;

        // Activate the sprite
        targetSprite.SetActive(true);
    }

    // Call this method to start the game
    public void StartGame()
    {
        // Reset variables
        score = 0;
        totalClicks = 0;
        accurateClicks = 0;

        // Spawn the first sprite
        SpawnSprite();
    }

    // Call this method to stop spawning and present the final score
    public void EndGame()
    {
        // Deactivate the target sprite
        targetSprite.SetActive(false);

        // Calculate accuracy percentage
        float accuracyPercentage = (totalClicks > 0) ? ((float)accurateClicks / totalClicks) * 100 : 0;

        // Update the existing scoreText with the final score and accuracy percentage
        scoreText.text = "Final Score: " + score + " accurate clicks out of " + totalClicks + " total clicks (" + accuracyPercentage.ToString("F2") + "%)";

        // Show the result canvas
        resultCanvas.gameObject.SetActive(true);
    }
}
