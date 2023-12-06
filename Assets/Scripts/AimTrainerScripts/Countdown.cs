using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public int duration = 30;
    public int timeRemaining;
    public bool isCountingDown = false;
    public TextMeshProUGUI countdownText; // Reference to your TextMeshPro text component
    public ClickSpriteHandler clickSpriteHandler; // Reference to the ClickSpriteHandler script

    private void Start()
    {
        clickSpriteHandler = FindObjectOfType<ClickSpriteHandler>();
        Begin();
    }

    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            StartCoroutine(CountdownCoroutine());
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        while (timeRemaining > 0)
        {
            // Update the TextMeshPro text with the current countdown value
            if (countdownText != null)
            {
                countdownText.text = "Time left: " + timeRemaining.ToString();
            }

            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        // Ensure that the countdown text is set to 0 when the countdown is complete
        if (countdownText != null)
        {
            countdownText.text = "Time is up!";
        }

        isCountingDown = false;

        // Call EndGame in ClickSpriteHandler to stop spawning and present the final score
        clickSpriteHandler.EndGame();
    }
}
