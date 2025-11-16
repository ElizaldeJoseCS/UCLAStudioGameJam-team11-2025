using UnityEngine;
using UnityEngine.UI; // Required for Button functionality

public class GameManager : MonoBehaviour
{
    // Reference to your Start button (optional if assigning directly in editor)
    // Reference to your Stop button (optional if assigning directly in editor)
    public Button stopButton;
    public Button startButton;
    [SerializeField] GameObject s1Button;
    [SerializeField] GameObject s2Button;

    // Example of a game state variable
    private bool gameRunning = false;

    //private float counter = 0f;

    void Start()
    {
        // Optional: Assign button click listeners in code
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopGame);
        }

        // Initialize game state (e.g., game starts stopped)
        gameRunning = false; 
    }

    public void StartGame()
    {
        if (!gameRunning)
        {
            Debug.Log("Counter Started!");
            gameRunning = true;
            // Add your game start logic here (e.g., enable player movement, spawn enemies)
            Time.timeScale = 1f; // Resumes time if paused


            s1Button.SetActive(false);

        }
    }

    public void StopGame()
    {
        if (gameRunning)
        {
            Debug.Log("Game Stopped!");
            gameRunning = false;
            // Add your game stop logic here (e.g., disable player movement, clear enemies)
            Time.timeScale = 0f; // Pauses the game
        }
    }
}