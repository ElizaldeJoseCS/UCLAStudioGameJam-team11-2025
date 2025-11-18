using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayButton : MonoBehaviour
{
[SerializeField] GameObject soundPanel;
[SerializeField] GameObject playButton;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        soundPanel.SetActive(!soundPanel.activeSelf);
    }
}


    void OnJump()
    {
        playButton.SetActive(true);

    }
    void OnReleaseButton()
    { 
        LoadNextScene();
    }
    public void LoadNextScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
