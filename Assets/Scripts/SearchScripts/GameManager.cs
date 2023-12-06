using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject trianglePrefab;
    public GameObject[] wrongSpritePrefabs; // Array of wrong sprite prefabs
    public int numberOfTriangles = 10;
    public int numberOfWrongSprites = 30;

    public Canvas resultCanvas;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool gameEnded = false;

    void Start()
    {
        startTime = Time.time;

        SpawnSprites();
    }

    void Update()
    {
        if(!gameEnded)
        {
            // Update the timer text with the elapsed time
            float elapsedTime = Time.time - startTime;
            timerText.text = "Time: " + elapsedTime.ToString("F2") + " seconds";
        }

    }

    void SpawnSprites()
    {
        SpawnTriangles();
        SpawnWrongSprites();
    }

    void SpawnTriangles()
    {
        for (int i = 0; i < numberOfTriangles; i++)
        {
            Instantiate(trianglePrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    void SpawnWrongSprites()
    {
        for (int i = 0; i < numberOfWrongSprites; i++)
        {
            // Randomly select a wrong sprite prefab from the array
            GameObject wrongSpritePrefab = wrongSpritePrefabs[Random.Range(0, wrongSpritePrefabs.Length)];
            Instantiate(wrongSpritePrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        return new Vector3(x, y, 0f);
    }

    // Called when any prefab is found
    public void PrefabFound()
    {
        numberOfTriangles--;

        // Check if all triangles are found
        if (numberOfTriangles == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // Set the result text on the canvas
        resultText.text = "All triangles found!";

        gameEnded = true;

        // Delay for a few seconds and then clear all prefabs
        StartCoroutine(ClearPrefabsAfterDelay(0f));

        // Enable the result canvas
        resultCanvas.gameObject.SetActive(true);
    }

    IEnumerator ClearPrefabsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Find and destroy all game objects with the "SpawnedPrefab" tag
        GameObject[] spawnedPrefabs = GameObject.FindGameObjectsWithTag("SpawnedPrefab");
        foreach (GameObject prefab in spawnedPrefabs)
        {
            Destroy(prefab);
        }

        // Display the total time it took to find all triangles
        float totalTime = Time.time - startTime;
        timerText.text = "Total Time: " + totalTime.ToString("F2") + " seconds";
    }
}
