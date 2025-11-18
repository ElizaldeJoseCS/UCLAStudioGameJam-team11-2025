using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MinigameManagerLevelFour : MonoBehaviour
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
    [SerializeField] GameObject TimeGame; // set active or inactive
    [SerializeField] GameObject timer; // info about fail or success
    [SerializeField] GameObject winArt3;
    [SerializeField] GameObject fourthMinigameArt;
    [SerializeField] GameObject HoldAndRelease2;// set active or inactive
    [SerializeField] GameObject tapper2; // info about fail or success
    [SerializeField] GameObject winArt4;
    [SerializeField] GameObject fifthMinigameArt;
    [SerializeField] GameObject DredgeGame;// set active or inactive
    [SerializeField] GameObject pointer; // info about fail or success
    [SerializeField] GameObject winArt5;
    [SerializeField] GameObject sixthMinigameArt;
    [SerializeField] GameObject StackingGame;// set active or inactive
    [SerializeField] GameObject stacker; // info about fail or success
    [SerializeField] GameObject winArt6;

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
            checkGame1();
        }
        else if (tapper.activeInHierarchy)
        {
            checkGame2();
        }
        else if (timer.activeInHierarchy)
        {
            checkGame3();
        }
        else if (tapper2.activeInHierarchy)
        {
            checkGame4();
        }
        else if (pointer.activeInHierarchy)
        {
            checkGame4();
        }
        else if (stacker.activeInHierarchy)
        {
            checkGame4();
        }
    }

    void checkGame1()
    {
        // update this to cursor level four later
        if (cursor.GetComponent<CursorLevelFour>().isFinished())
        {
            if (cursor.GetComponent<CursorLevelFour>().winGame())
                StartCoroutine(winMinigame1());
            else
                StartCoroutine(loseMinigame1());
        }
    }

    void checkGame2()
    {
        if (tapper.GetComponent<tapAndHold>().isFinished())
        {
            if (tapper.GetComponent<tapAndHold>().win())
                StartCoroutine(winMinigame2());
            else
                StartCoroutine(loseMinigame2());
        }
    }

    void checkGame3()
    {
        if (timer.GetComponent<TimeManagerLevelFour>().isFinished())
        {
            if (timer.GetComponent<TimeManagerLevelFour>().winGame())
                StartCoroutine(winMinigame3());
            else
                StartCoroutine(loseMinigame3());
        }
    }

    void checkGame4()
    {
        if (tapper2.GetComponent<tapAndHold>().isFinished())
        {
            if (tapper2.GetComponent<tapAndHold>().win())
                StartCoroutine(winMinigame4());
            else
                StartCoroutine(loseMinigame4());
        }
    }

    void checkGame5()
    {
        if (pointer.GetComponent<pointerScript>().isFinished())
        {
            if (pointer.GetComponent<pointerScript>().winGame())
                StartCoroutine(winMinigame4());
            else
                StartCoroutine(loseMinigame4());
        }
    }

    void checkGame6()
    {
        // replace this with level four later
        if (stacker.GetComponent<stackControllerLevelFour>().isFinished())
        {
            if (stacker.GetComponent<stackControllerLevelFour>().winGame())
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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        TimeGame.SetActive(false);
        winArt3.SetActive(true);

        StartCoroutine(prepareMinigameFour());
    }

    IEnumerator loseMinigame3()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        thirdMinigameArt.SetActive(false);
        TimeGame.SetActive(false);
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
        HoldAndRelease2.SetActive(false);
        winArt4.SetActive(true);

        StartCoroutine(prepareMinigameFive());
    }

    IEnumerator loseMinigame4()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        fourthMinigameArt.SetActive(false);
        HoldAndRelease2.SetActive(false);
        loseArt.SetActive(true);
        StartCoroutine(restartLevel());
    }

    IEnumerator prepareMinigameFive()
    {
        yield return new WaitForSeconds(1.0f);
        winArt4.SetActive(false);
        fifthMinigameArt.SetActive(true);
    }

    // fourth game is stacking game
    IEnumerator winMinigame5()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        fifthMinigameArt.SetActive(false);
        DredgeGame.SetActive(false);
        winArt5.SetActive(true);

        StartCoroutine(nextScene());
    }

    IEnumerator loseMinigame5()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        fifthMinigameArt.SetActive(false);
        DredgeGame.SetActive(false);
        loseArt.SetActive(true);
        StartCoroutine(restartLevel());
    }

    IEnumerator prepareMinigameSix()
    {
        yield return new WaitForSeconds(1.0f);
        winArt5.SetActive(false);
        sixthMinigameArt.SetActive(true);
    }

    // fourth game is stacking game
    IEnumerator winMinigame6()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        sixthMinigameArt.SetActive(false);
        StackingGame.SetActive(false);
        winArt6.SetActive(true);

        StartCoroutine(nextScene());
    }

    IEnumerator loseMinigame6()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        sixthMinigameArt.SetActive(false);
        StackingGame.SetActive(false);
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
