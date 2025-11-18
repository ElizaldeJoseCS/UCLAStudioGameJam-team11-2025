using UnityEngine;
using UnityEngine.InputSystem;

public class stackControllerLevelFour : MonoBehaviour
{
    [SerializeField] int numSlices = 5;
    [SerializeField] GameObject stackSlice;
    [SerializeField] float speed = 6f;
    [SerializeField] int bounds = 4;
    [SerializeField] float padding = 0.6f;

    [SerializeField] GameObject pan;
    [SerializeField] GameObject flowers;
    [SerializeField] GameObject onion;
    [SerializeField] GameObject potatoe;
    [SerializeField] GameObject kraken;

    private bool isDropping = false;
    private int iteration = 1;
    private GameObject currentSlice;
    private bool loss = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSlice = Instantiate(pan, new Vector3(0, stackSlice.transform.position.y + padding * iteration, 0), Quaternion.identity);
        iteration += 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDropping)
            moveTheSlice();
        else
        {
            makeNewSliceLogic();
            checkIfFail();
        }
    }

    void moveTheSlice()
    {
        currentSlice.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);

        if (Mathf.Abs(currentSlice.transform.position.x) > bounds)
        {
            // avoiding buggy out of bounds errors
            // moving right
            if (speed > 0)
            {
                currentSlice.transform.position = new Vector2(bounds - 0.1f, currentSlice.transform.position.y);
            }
            // moving left
            else
            {
                currentSlice.transform.position = new Vector2(-bounds + 0.1f, currentSlice.transform.position.y);
            }
            speed *= -1;
        }
    }

    public void OnJump()
    {
        isDropping = true;
        currentSlice.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -0.01f);
        currentSlice.GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    void makeNewSliceLogic()
    {
        if (currentSlice.GetComponent<Rigidbody2D>().linearVelocity.y == 0 && currentSlice.GetComponent<Rigidbody2D>().linearVelocity.x == 0)
        {
            // create new slice
            if (iteration <= numSlices)
            {
                if (iteration == 2)
                {
                    GameObject newSlice = Instantiate(kraken, new Vector3(0, stackSlice.transform.position.y + padding * iteration, 0), Quaternion.identity);
                    currentSlice = newSlice;
                }
                else if (iteration == 3)
                {
                    GameObject newSlice = Instantiate(potatoe, new Vector3(0, stackSlice.transform.position.y + padding * iteration, 0), Quaternion.identity);
                    currentSlice = newSlice;
                }
                else if (iteration == 4)
                {
                    GameObject newSlice = Instantiate(onion, new Vector3(0, stackSlice.transform.position.y + padding * iteration, 0), Quaternion.identity);
                    currentSlice = newSlice;
                }
                else
                {
                    GameObject newSlice = Instantiate(flowers, new Vector3(0, stackSlice.transform.position.y + padding * iteration, 0), Quaternion.identity);
                    currentSlice = newSlice;
                }

                isDropping = false;
            }
            iteration += 1;
        }
    }

    void checkIfFail()
    {
        if (currentSlice.transform.position.y < -5)
        {
            loss = true;
        }
    }

    public bool isFinished()
    {
        // this might not be right it might return finished if numSlices = 5 instead of 6
        return ((iteration > numSlices + 1) || loss);
    }

    public bool winGame()
    {
        return !loss;
    }
}
