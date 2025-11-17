using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject art1;
    [SerializeField] GameObject HoldAndRelease;
    [SerializeField] GameObject tapper;

    //just for the background
    int numPressed = 0;

    void OnReleaseButton()
    {
        // just for the one time background
        if (numPressed == 0)
        {
            blurBG.SetActive(true);
            art1.SetActive(true);
            numPressed++;
        }
        else if (numPressed == 1)
        {
            blurBG.GetComponent<SpriteRenderer>().sortingOrder = 5;
            HoldAndRelease.SetActive(true);
            numPressed++;
        }

            tapper.GetComponent<tapAndHold>().OnReleaseButton();
    }

    void OnJump()
    {
        tapper.GetComponent<tapAndHold>().OnJump();
    }
}
