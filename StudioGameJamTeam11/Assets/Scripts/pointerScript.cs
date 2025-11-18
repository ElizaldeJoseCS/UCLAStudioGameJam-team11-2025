using UnityEngine;
using UnityEngine.InputSystem;

public class pointerScript : MonoBehaviour
{
    [SerializeField] float timeLimit = 10f;
    [SerializeField] GameObject rotatingCircle;
    private float timeElapsed = 0f;
    private bool lost = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            //reloads the scene
            lost = true;
        }
    }

    public void OnJump()
    {
        rotatingCircle.GetComponent<RotateCircle>().StartRotation();
        if (transform.position.y == 1)
        { 
            transform.position = new Vector3(0, 2.5f, 0);
            Debug.Log(transform.position.y);
        }
        else
        {
            transform.position = new Vector3(0, 1f, 0);
            Debug.Log(transform.position.y);
        }
    }

    public bool isFinished()
    {
        return (timeElapsed >= timeLimit) || lost;
    }

    public bool winGame()
    {
        return !lost;
    }
}
