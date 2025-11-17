using UnityEngine;
using System.Collections;

public class minigameManager : MonoBehaviour
{
    [SerializeField] GameObject blurBG;
    [SerializeField] GameObject HoldAndRelease;
    [SerializeField] GameObject tapper;
    [SerializeField] GameObject winArt1;
    [SerializeField] GameObject loseArt1;
    [SerializeField] GameObject startingArt;

    void checkIfPassOrFail()
    {
        // if 10% of hits is greater than misses then pass
        if (tapper.GetComponent<tapAndHold>().isFinished())
        {
            if (tapper.GetComponent<tapAndHold>().win())
            {
                StartCoroutine(winMinigame1());
            }
            else
            {
                StartCoroutine(loseMinigame1());
            }

        }
    }

    IEnumerator winMinigame1()
    {
        yield return new WaitForSeconds(2.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        winArt1.SetActive(true);
        HoldAndRelease.SetActive(false);
        startingArt.SetActive(false);
    }

    IEnumerator loseMinigame1()
    {
        yield return new WaitForSeconds(2.0f);
        blurBG.GetComponent<SpriteRenderer>().sortingOrder = 2;
        loseArt1.SetActive(true);
        HoldAndRelease.SetActive(false);
        startingArt.SetActive(false);  
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tapper.activeInHierarchy)
            checkIfPassOrFail();
    }
}
