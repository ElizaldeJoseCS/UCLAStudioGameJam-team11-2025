using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use this for TextMeshPro (better text)

public class GameManager : MonoBehaviour
{
    // --- Drag these in the Inspector ---
    [Tooltip("The button that starts the timer.")]
    public GameObject startButton;
    
    [Tooltip("The button that stops the timer.")]
    public GameObject stopButton;
    
    [Tooltip("The TextMeshPro UI element to show results.")]
    public TextMeshProUGUI resultText;
    // ------------------------------------

    private bool gameRunning = false;
    private float startTime; // Variable to store the exact time the timer started

    void Start()
    {
        // Set the initial game state
        startButton.SetActive(true);
        stopButton.SetActive(false); // Hide stop button initially
        resultText.text = "Try to guess 10 seconds!\nClick Start to begin.";
    }

    public void StartGame()
    {
        if (gameRunning) return; // Safety check

        gameRunning = true;
        
        // --- THIS IS THE KEY ---
        // Store the exact moment in time when the button was clicked
        startTime = Time.time;
        // -----------------------

        Debug.Log("Counter Started!");

        // Update UI
        startButton.SetActive(false);
        stopButton.SetActive(true);
        resultText.text = "Timing... Click Stop when you think 10s have passed!";
    }

    public void StopGame()
    {
        if (!gameRunning) return; // Safety check

        gameRunning = false;

        // --- THIS IS THE OTHER KEY ---
        // Calculate the difference between now and the start time
        float elapsedTime = Time.time - startTime;
        // -----------------------------

        // Calculate how close the player was to 10 seconds
        float difference = Mathf.Abs(elapsedTime - 10f);

        Debug.Log($"Counter Stopped! Elapsed time: {elapsedTime} seconds");

        // Update UI
        stopButton.SetActive(false);
        startButton.SetActive(true); // Show start button to let them play again
        
        // Display the result, formatted to 2 decimal places (e.g., "10.12")
        resultText.text = $"You stopped at {elapsedTime:F2} seconds!\n" +
                          $"You were {difference:F2} seconds off.";
    }
}