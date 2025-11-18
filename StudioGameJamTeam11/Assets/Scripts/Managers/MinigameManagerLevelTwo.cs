using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MinigameManagerLevelTwo : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject loseArt;
    [SerializeField] GameObject startingArt;
    [SerializeField] GameObject rapidPattern; // set active or inactive
    [SerializeField] GameObject cursor; // infor about win or lose
    [SerializeField] GameObject winArt1;
    [SerializeField] GameObject secondMinigameArt;
    [SerializeField] GameObject HoldAndRelease; // set active or inactive
    [SerializeField] GameObject tapper; // info about win or lose
    [SerializeField] GameObject winArt2;
    [SerializeField] GameObject thirdMinigameArt;
    [SerializeField] GameObject timeGuess; // set active or inactive
    [SerializeField] GameObject timeManager; // info about fail or success
    [SerializeField] GameObject winArt3;
    [SerializeField] GameObject fourthMinigameArt;
    [SerializeField] GameObject stackingGame;// set active or inactive
    [SerializeField] GameObject stackingManager; // info about fail or success
    [SerializeField] GameObject winArt4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check which minigame is active and check for win/lose
        if (cursor.activeInHierarchy)
        {
            checkRapidPattern();
        }
        else if (tapper.activeInHierarchy)
        {
            checkHoldAndRelease();
        }
        else if (timeGuess.activeInHierarchy)
        {
            checkTimeGuess();
        }
        else if (stackingManager.activeInHierarchy)
        {
            checkStackingGame();
        }
    }

    void checkRapidPattern()
    {
        if (cursor.GetComponent<cursor>().isFinished())
        {
            if (cursor.GetComponent<cursor>().winGame())
                StartCoroutine(winMinigame1());
            else
                StartCoroutine(loseMinigame1());
        }
    }

    void checkHoldAndRelease()
    {
        if (tapper.GetComponent<tapAndHold>().isFinished())
        {
            if (tapper.GetComponent<tapAndHold>().win())
                StartCoroutine(winMinigame2());
            else
                StartCoroutine(loseMinigame2());
        }
    }

    void checkTimeGuess()
    {
        if (timeManager.GetComponent<TimeManagerLevelTwo>().isFinished())
        {
            if (timeManager.GetComponent<TimeManagerLevelTwo>().winGame())
                StartCoroutine(winMinigame3());
            else
                StartCoroutine(loseMinigame3());
        }
    }

    void checkStackingGame()
    {
        if (stackingManager.GetComponent<stackController>().isFinished())
        {
            if (stackingManager.GetComponent<stackController>().winGame())
                StartCoroutine(winMinigame4());
            else
                StartCoroutine(loseMinigame4());
        }
    }

    // first game is rapid pattern
    IEnumerator winMinigame1()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        winArt1.SetActive(true);
        rapidPattern.SetActive(false);
        startingArt.SetActive(false);

        StartCoroutine(prepareMinigameTwo());
    }

    IEnumerator loseMinigame1()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        loseArt.SetActive(true);
        rapidPattern.SetActive(false);
        startingArt.SetActive(false);

        StartCoroutine(restartLevel());
    }

    IEnumerator restartLevel()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator prepareMinigameTwo()
    {
        yield return new WaitForSeconds(1.0f);
        winArt1.SetActive(false);
        secondMinigameArt.SetActive(true);
    }

    // second game is hold and release
    IEnumerator winMinigame2()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        secondMinigameArt.SetActive(false);
        HoldAndRelease.SetActive(false);
        winArt2.SetActive(true);

        StartCoroutine(prepareMinigameThree());
    }

    IEnumerator loseMinigame2()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        secondMinigameArt.SetActive(false);
        HoldAndRelease.SetActive(false);
        loseArt.SetActive(true);
        StartCoroutine(restartLevel());
    }

    IEnumerator prepareMinigameThree()
    {
        yield return new WaitForSeconds(1.0f);
        winArt2.SetActive(false);
        thirdMinigameArt.SetActive(true);
    }

    // third game is time guess
    IEnumerator winMinigame3()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        thirdMinigameArt.SetActive(false);
        timeGuess.SetActive(false);
        winArt3.SetActive(true);

        StartCoroutine(prepareMinigameFour());
    }

    IEnumerator loseMinigame3()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        thirdMinigameArt.SetActive(false);
        timeGuess.SetActive(false);
        loseArt.SetActive(true);
        StartCoroutine(restartLevel());
    }

    IEnumerator prepareMinigameFour()
    {
        yield return new WaitForSeconds(1.0f);
        winArt3.SetActive(false);
        fourthMinigameArt.SetActive(true);
    }

    // fourth game is stacking game
    IEnumerator winMinigame4()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        fourthMinigameArt.SetActive(false);
        stackingGame.SetActive(false);
        winArt4.SetActive(true);

        StartCoroutine(nextScene());
    }

    IEnumerator loseMinigame4()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        fourthMinigameArt.SetActive(false);
        stackingGame.SetActive(false);
        loseArt.SetActive(true);
        StartCoroutine(restartLevel());
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2.0f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
