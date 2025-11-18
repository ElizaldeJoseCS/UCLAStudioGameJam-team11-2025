using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayButton : MonoBehaviour
{
[SerializeField] GameObject playButton;




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
