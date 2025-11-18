using UnityEngine;
using TMPro; // Use this for TextMeshPro

public class TimeManagerLevelTwo : MonoBehaviour
{
    // --- Drag these in the Inspector ---
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject stopButton;
    [SerializeField]
    private TextMeshPro resultText;
    // ------------------------------------

    private bool gameRunning = false;
    private float startTime;

    private bool gameFinished = false;
    private bool win = false;

    void Start()
    {
        // Set the initial game state
        if (startButton) startButton.SetActive(true);
        if (stopButton) stopButton.SetActive(false);

        if (resultText)
        {
            resultText.text = "Try to guess 10 seconds!\n";
        }
    }

    // --- NEW METHOD ---
    // Update is called once per frame
    void Update()
    {
        // Check if the spacebar was just pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If the game is running, stop it
            if (gameRunning)
            {
                StopGame();
            }
            // If the game is NOT running, start it
            else
            {
                StartGame();
            }
        }
    }
    // ------------------

    public void StartGame()
    {
        if (gameRunning) return; // Safety check
        gameRunning = true;

        // Store the exact moment in time when the button was clicked
        startTime = Time.time;
        // -----------------------


        // Update UI
        if (startButton)
        {
            startButton.SetActive(false);
        }
        if (stopButton) stopButton.SetActive(true);
        if (resultText) resultText.text = "Timing... Click Stop!";
    }

    public void StopGame()
    {
        if (!gameRunning) return; // Safety check
        gameRunning = false;

        // Calculate the difference between now and the start time
        float elapsedTime = Time.time - startTime;
        // -----------------------------

        float difference = Mathf.Abs(elapsedTime - 10f);

        // Update UI
        if (stopButton) stopButton.SetActive(false);
        if (startButton) startButton.SetActive(true);

        // Display the result
        if (resultText)
        {

            if (elapsedTime >= 7 && elapsedTime <= 13)
            {
                resultText.text = $"Close Enough, You stopped at {elapsedTime:F2} seconds!\n";
                win = true;

            }
            else if (elapsedTime < 7)
            {
                resultText.text = $"Yikes, {elapsedTime:F2} seconds, You gave some poor axolotyl Salmonella. \n" + 
                                   "He's dead and you're fired Brodie, tough luck.";
            }
            else
            {
                resultText.text = $"You timed {elapsedTime:F2} seconds, This thing is burnt and you're fired\n";
            }
            gameFinished = true;
        }
    }

    public bool isFinished()
    {
        return gameFinished;
    }

    public bool winGame()
    {
        return win;
    }
}