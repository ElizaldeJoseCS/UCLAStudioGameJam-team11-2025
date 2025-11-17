using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class minigameManager : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject HoldAndRelease;
    [SerializeField] GameObject tapper;
    [SerializeField] GameObject winArt1;
    [SerializeField] GameObject loseArt1;
    [SerializeField] GameObject startingArt;
    [SerializeField] GameObject secondMinigameArt;
    [SerializeField] GameObject timeGuess;
    [SerializeField] GameObject winArt2;
    [SerializeField] GameObject loseArt2;

    void checkHoldAndRelease()
    {
        // if 10% of hits is greater than misses then pass
        if (tapper.GetComponent<tapAndHold>().isFinished())
        {
            if (tapper.GetComponent<tapAndHold>().win())
                StartCoroutine(winMinigame1());
            else
                StartCoroutine(loseMinigame1());
        }
    }

    void checkTimeGuess()
    {
        if (timeGuess.GetComponent<TimeManager>().isFinished())
        {
            if (timeGuess.GetComponent<TimeManager>().winGame())
                StartCoroutine(winMinigame2());
            else
                StartCoroutine(loseMinigame2());
        }
    }

    IEnumerator winMinigame1()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        winArt1.SetActive(true);
        HoldAndRelease.SetActive(false);
        startingArt.SetActive(false);

        StartCoroutine(nextMiniGame());
    }

    IEnumerator loseMinigame1()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        loseArt1.SetActive(true);
        HoldAndRelease.SetActive(false);
        startingArt.SetActive(false);

        StartCoroutine(backToMainMenu());
    }

    IEnumerator backToMainMenu()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }

    IEnumerator nextMiniGame()
    {
        yield return new WaitForSeconds(1.0f);
        winArt1.SetActive(false);
        secondMinigameArt.SetActive(true);
    }

    IEnumerator winMinigame2()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        secondMinigameArt.SetActive(false);
        timeGuess.SetActive(false);
        winArt2.SetActive(true);

        StartCoroutine(nextScene());
    }

    IEnumerator loseMinigame2()
    {
        yield return new WaitForSeconds(1.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        secondMinigameArt.SetActive(false);
        timeGuess.SetActive(false);
        loseArt2.SetActive(true);
        StartCoroutine(backToMainMenu());
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(3);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tapper.activeInHierarchy)
            checkHoldAndRelease();

        if(timeGuess.activeInHierarchy)
            checkTimeGuess();

    }
}
