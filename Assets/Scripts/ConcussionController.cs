using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ConcussionController : MonoBehaviour
{
    public GameObject redCirclePrefab;
    public GameObject yellowSquarePrefab;
    public TextMeshProUGUI correctPicksText;
    public TextMeshProUGUI averageTimeText;
    public TextMeshProUGUI Q;
    public TextMeshProUGUI P;

    private float totalTime;
    private int totalAttempts;
    private float gameTimer = 30f;
    private float summaryDisplayTime = 10f;
    private bool gameEnded = false;
    private float correctTotalTime;
    private int correctAttempts;
    private List<float> inputTimes = new List<float>();
    public Canvas resultCanvas;
    public TextMeshProUGUI resultText;
    private GameObject currentShape;

    private void Start()
    {
        Destroy(currentShape);
        SpawnShape();
    }

    private void SpawnShape()
    {
        // Use a coroutine to delay the destruction of the current shape
        StartCoroutine(SpawnShapeCoroutine());
    }

private System.Collections.IEnumerator SpawnShapeCoroutine()
{
    // Destroy the previous shape if it exists
    Destroy(currentShape);

    // Wait for a short delay before spawning the new shape
    yield return new WaitForSeconds(0f);

    GameObject shapePrefab = Random.Range(0, 2) == 0 ? redCirclePrefab : yellowSquarePrefab;
    currentShape = Instantiate(shapePrefab, Vector3.zero, Quaternion.identity);
}

    private void Update()
    {
        if (!gameEnded)
        {
            gameTimer -= Time.deltaTime;

            if (gameTimer <= 0f)
            {
                EndGame();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.P))
            {
                CheckInput();
            }
        }
    }

    private void CheckInput()
    {
        // If currentShape is null, treat it as an incorrect input
        if (currentShape == null)
        {
            Debug.LogError("currentShape is null in CheckInput");
            totalAttempts++;
            UpdateResult(false);
            SpawnShape(); // Spawn the next shape
            return;
        }

        // Continue with the existing logic for handling input when currentShape is not null
        string keyPressed = Input.GetKeyDown(KeyCode.Q) ? "RedCircle" : (Input.GetKeyDown(KeyCode.P) ? "YellowSquare" : "");
        string currentShapeTag = currentShape.tag.ToLower();

        Debug.Log($"Expected: {keyPressed.ToLower()}, Actual: {currentShapeTag}");

        if (currentShapeTag == keyPressed.ToLower())
        {
            float currentTime = Time.time;
            correctTotalTime += currentTime;
            correctAttempts++;

            // Add time to timer
            inputTimes.Add(currentTime);
        }

        totalAttempts++;
        UpdateResult(currentShapeTag == keyPressed.ToLower());

        // Spawn the next shape
        SpawnShape();
    }

    private void UpdateResult(bool success)
    {
        if (success)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        CalculateAndDisplayResults();
    }

    private void CalculateAndDisplayResults()
    {
        float percentage = (correctAttempts / (float)totalAttempts) * 100f;
        correctPicksText.text = $"Correct Picks: {percentage:F2}%";

        if (inputTimes.Count > 0)
        {
            // Calculate and display the average time for correct inputs
            float sumOfTimes = 0f;
            foreach (float time in inputTimes)
            {
                sumOfTimes += time;
            }

            float averageTime = sumOfTimes / inputTimes.Count;
            averageTimeText.text = $"Average Time: {averageTime:F2}s";
        }
    }    
    private void EndGame()
    {
        gameEnded = true;

        correctPicksText.gameObject.SetActive(false);
        averageTimeText.gameObject.SetActive(false);
        Q.gameObject.SetActive(false);
        P.gameObject.SetActive(false);
        redCirclePrefab.gameObject.SetActive(false);
        yellowSquarePrefab.gameObject.SetActive(false);

        resultCanvas.gameObject.SetActive(true);

        float percentage = (correctAttempts / (float)totalAttempts) * 100f;
        resultText.text = $"Correct Inputs: {correctAttempts}\nTotal Inputs: {totalAttempts}\nAccuracy: {percentage:F2}%";

        CalculateAndDisplayResults();

        StartCoroutine(DelayedTransition());
    }

    private System.Collections.IEnumerator DelayedTransition()
    {
        yield return new WaitForSeconds(summaryDisplayTime);

        // You might want to replace "MainMenu" with the actual name of your main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
