using UnityEngine;
using UnityEngine.InputSystem;

public class tapAndHold : MonoBehaviour
{
    [SerializeField] float animTime = 0.1f;

    //private variables
    bool validTarget = false;
    bool holding = false;
    bool destory = false;
    bool validHoldTarget = false;
    bool colorChanged = false;
    SpriteRenderer spriteRenderer;
    float currTime = 0f;
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
            if(currTime >= animTime)
                {
                spriteRenderer.color = Color.black;
                colorChanged = false;
                currTime = 0f;
            }
        }
    }

    void OnJump()
    {
        animEnlarge();

        // tap mechanics
        if (validTarget)
        {
            destory = true;
        }
        else 
        {
            Debug.Log("missed");
        }

        holding = true;
    }

    void OnReleaseButton()
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
                destory = false;
                changeColor();
            }
        }

        // hold mechanics
        if (holding)
        {
            validHoldTarget = true;
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
                changeColor();
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
}
