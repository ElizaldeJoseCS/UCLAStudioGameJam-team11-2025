using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerLevelFour : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject startingArt;
    [SerializeField] GameObject firstMinigame;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject secondMinigameArt;
    [SerializeField] GameObject secondMinigame;
    [SerializeField] GameObject tapper;
    [SerializeField] GameObject thirdMinigameArt;
    [SerializeField] GameObject thirdMinigame;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject fourthMinigameArt;
    [SerializeField] GameObject fourthMinigame;
    [SerializeField] GameObject tapper2;
    [SerializeField] GameObject fifthMinigameArt;
    [SerializeField] GameObject fifthMinigame;
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject sixthMinigameArt;
    [SerializeField] GameObject sixthMinigame;
    [SerializeField] GameObject stackManager;

    //just for the background
    int numPressed = 0;

    void OnReleaseButton()
    {
        // just for the one time background
        if (numPressed == 0)
        {
            blurBG.SetActive(true);
            startingArt.SetActive(true);
            numPressed++;
        }
        // next press will bring up the hold and release minigame
        else if (numPressed == 1)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            firstMinigame.SetActive(true);
            numPressed++;
        }
        // if the second minigame art is active, next press begins the second minigame
        else if (secondMinigameArt.activeInHierarchy && numPressed == 2)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            secondMinigame.SetActive(true);
            numPressed++;
        }
        else if (thirdMinigameArt.activeInHierarchy && numPressed == 3)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            thirdMinigame.SetActive(true);
            numPressed++;
        }
        else if (fourthMinigameArt.activeInHierarchy && numPressed == 4)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            fourthMinigame.SetActive(true);
            numPressed++;
        }
        else if (fifthMinigameArt.activeInHierarchy && numPressed == 5)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            fifthMinigame.SetActive(true);
            numPressed++;
        }
        else if (sixthMinigameArt.activeInHierarchy && numPressed == 6)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            sixthMinigame.SetActive(true);
            numPressed++;
        }

        if (tapper.activeInHierarchy)
            tapper.GetComponent<tapAndHold>().OnReleaseButton();
        if (tapper2.activeInHierarchy)
            tapper2.GetComponent<tapAndHold>().OnReleaseButton();
    }

    void OnJump()
    {
        if (stackManager.activeInHierarchy)
            stackManager.GetComponent<stackControllerLevelFour>().OnJump();
        if (cursor.activeInHierarchy)
            cursor.GetComponent<CursorLevelFour>().OnJump();
        if (pointer.activeInHierarchy)
            pointer.GetComponent<pointerScript>().OnJump();
        if (tapper.activeInHierarchy)
            tapper.GetComponent<tapAndHold>().OnJump();
        if (tapper2.activeInHierarchy)
            tapper2.GetComponent<tapAndHold>().OnJump();
    }
}
