using UnityEngine;

public class tapAndHold : MonoBehaviour
{
    [SerializeField] float animTime = 0.1f;
    [SerializeField] int totalTargets = 10;

    //private variables
    bool validTarget = false;
    bool holding = false;
    bool destory = false;
    bool validHoldTarget = false;
    bool colorChanged = false;
    SpriteRenderer spriteRenderer;
    float currTime = 0f;

    int hits = 0;
    int misses = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChanged)
        {
            currTime += Time.deltaTime;
            if (currTime >= animTime)
            {
                spriteRenderer.color = Color.black;
                colorChanged = false;
                currTime = 0f;
            }
        }
    }

    public void OnJump()
    {
        animEnlarge();
        if(gameObject.activeInHierarchy)
        SFXandMusic.instance.PlaySFX("stacking", transform.position);

        // tap mechanics
        if (validTarget)
        {
            destory = true;
        }
        else 
        {
            // I don't think I want to add anything
            // for if you click and miss only if a target
            // leaves the screen without being hit
        }

        holding = true;
    }

    public void OnReleaseButton()
    {
        animReduce();

        holding = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // tap mechanics
        validTarget = true;
        if (other.gameObject.CompareTag("Target"))
        {
            if (destory)
            {
                Destroy(other.gameObject);
                SFXandMusic.instance.PlaySFX("stacking", transform.position);
                destory = false;
                changeColor();
                hits++;
            }
        }

        // hold mechanics
        if (holding)
        {
            validHoldTarget = true;

            changeColor();
        }
        else
        {
            validHoldTarget = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // tap mechanics
        validTarget = false;

        // hold mechanics
        if (other.gameObject.CompareTag("Hold"))
        {
            if (holding && validHoldTarget)
            {
                Destroy(other.gameObject);
                SFXandMusic.instance.PlaySFX("stacking", transform.position);

                changeColor();
                hits++;
            }
        }
    }

    void animEnlarge()
    {
        transform.localScale = new Vector3(0.15f, 3f, 1);
    }

    void animReduce()
    {
        transform.localScale = new Vector3(0.1f, 2f, 1);
    }

    void changeColor()
    {
        spriteRenderer.color = Color.yellow;
        colorChanged = true;
    }

    public void targetMissed()
    {
        misses++;
    }   

    public bool win()
    {
        return (hits*0.2f) > misses;
    }

    public bool isFinished()
    {
        return (hits + misses) >= totalTargets;
    }
}
