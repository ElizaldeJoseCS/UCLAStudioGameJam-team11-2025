using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // Use this for TextMeshPro

public class InputManagerLevelThree : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject startingArt;
    [SerializeField] GameObject firstMinigame;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject secondMinigameArt;
    [SerializeField] GameObject secondMinigame;
    [SerializeField] GameObject stackManager;
    [SerializeField] GameObject thirdMinigameArt;
    [SerializeField] GameObject thirdMinigame;
    [SerializeField] GameObject tapper;
    [SerializeField] GameObject fourthMinigameArt;
    [SerializeField] GameObject fourthMinigame;
    [SerializeField] GameObject pointer;
    [SerializeField] TextMeshPro continueText;


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
            continueText.text = "";
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

        if (tapper.activeInHierarchy)
            tapper.GetComponent<tapAndHold>().OnReleaseButton();
    }

    void OnJump()
    {
        
        if (stackManager.activeInHierarchy)
            stackManager.GetComponent<stackControllerLevelThree>().OnJump();
        if (cursor.activeInHierarchy)
            cursor.GetComponent<CursorLevelThree>().OnJump();
        if (pointer.activeInHierarchy)
            pointer.GetComponent<pointerScript>().OnJump();
        if (tapper.activeInHierarchy)
            tapper.GetComponent<tapAndHold>().OnJump();
    }
}
