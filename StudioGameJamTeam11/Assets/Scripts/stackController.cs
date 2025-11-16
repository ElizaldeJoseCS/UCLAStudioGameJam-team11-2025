using UnityEngine;
using UnityEngine.InputSystem;

public class stackController : MonoBehaviour
{
    [SerializeField] GameObject stackSlice;
    [SerializeField] float speed = 3f;
    [SerializeField] int bounds = 4;

    private bool isDropping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isDropping)
            moveTheSlice();
    }

    void moveTheSlice()
    {
        stackSlice.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);

        if (Mathf.Abs(stackSlice.transform.position.x) > bounds)
        {
            // avoiding buggy out of bounds errors
            // moving right
            if (speed > 0)
            {
                stackSlice.transform.position = new Vector2(3.9f, stackSlice.transform.position.y);
            }
            // moving left
            else {
                stackSlice.transform.position = new Vector2(-3.9f, stackSlice.transform.position.y);
            }
            speed *= -1;
        }
    }

    void OnJump()
    {
        isDropping = true;
        stackSlice.GetComponent<Rigidbody2D>().gravityScale = 2;
    }
}
