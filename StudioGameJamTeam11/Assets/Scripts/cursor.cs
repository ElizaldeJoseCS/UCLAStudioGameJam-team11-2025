using UnityEngine;
using UnityEngine.InputSystem;

public class cursor : MonoBehaviour
{
    [SerializeField] public float cursorSpeed = 1f;
    [SerializeField] public int degreeBoundary = 40;
    [SerializeField] GameObject collisionDetector;
    private float cursorIncrement; // this will be changed positive to negative when we hit the bounds
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursorIncrement = cursorSpeed;
        collisionDetector.GetComponent<CollisionDetector>().setDegree(degreeBoundary);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkBounds();
    }

    void checkBounds()
    {
        // 0 - 40 and 320 - 360 = valid rotation bounds
        if(isOutsideBoundary(degreeBoundary))
        {
            cursorIncrement *= -1;
        }
        rotate();
    }

    void rotate()
    {
        transform.Rotate(0, 0, cursorIncrement, Space.Self);
    }

    // outside boundary = [40,320] for degree = 40
    bool isOutsideBoundary(int degree)
    {
        // angle is greater than degree and less than 360 - degree
        if (transform.localEulerAngles.z > degree && transform.localEulerAngles.z < (360 - degree))
        {
            // going counter clockwise
            if (cursorIncrement > 0)
            {
                // set the angle to be at the degree to avoid out of bounds bugs
                transform.rotation = Quaternion.Euler(0, 0, degree);
            }
            else 
            {
                transform.rotation = Quaternion.Euler(0,0, 360 - degree);
            }
            return true;
        }
        return false;
    }

    void OnJump()
    {
        // check if the collider is on the target
        if (collisionDetector.GetComponent<CollisionDetector>().IsTouching())
        {
            // hit
            collisionDetector.GetComponent<CollisionDetector>().Destroy();
        }
        // miss
        else 
        { 
            // implement the miss stuff here
        }

    }
}
