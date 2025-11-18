using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // Use this for TextMeshPro
 

public class inputManager : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject art1;
    [SerializeField] GameObject HoldAndRelease;
    [SerializeField] GameObject tapper;
    [SerializeField] GameObject secondMinigameArt;
    [SerializeField] GameObject timeGuess;
    [SerializeField] TextMeshPro startText;
    //just for the background
    int numPressed = 0;

    void OnReleaseButton()
    {
        // just for the one time background
        if (numPressed == 0)
        {
            blurBG.SetActive(true);
            art1.SetActive(true);
            startText.text = "";
            numPressed++;
        }
        // next press will bring up the hold and release minigame
        else if (numPressed == 1)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            HoldAndRelease.SetActive(true);
            numPressed++;
        }
        // if the second minigame art is active, next press begins the second minigame
        else if (secondMinigameArt.activeInHierarchy)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            timeGuess.SetActive(true);
        }

            tapper.GetComponent<tapAndHold>().OnReleaseButton();
    }

    void OnJump()
    {
        tapper.GetComponent<tapAndHold>().OnJump();
    }
}
