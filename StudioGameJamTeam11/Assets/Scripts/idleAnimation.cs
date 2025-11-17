using UnityEngine;

public class idleAnimation : MonoBehaviour
{
    [SerializeField] float downLoopTime = 1f;
    [SerializeField] float upLoopTime = 0.7f;
    [SerializeField] float restTime = 0.1f;
    [SerializeField] float distance = 0.7f;

    float currTime = 0f;
    float downSpeed;
    float upSpeed;

    public float amplitude = 1f;
    public float frequency = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        downSpeed = distance / downLoopTime;
        upSpeed = distance / upLoopTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currTime += Time.fixedDeltaTime;
        // going down
        if (currTime < downLoopTime)
        {
            transform.position += Vector3.down * downSpeed * Time.deltaTime;
            applySwaying();
        }
        // staying still at the bottom for a little
        else if (currTime < downLoopTime + restTime)
        { 
        }
        // going up
        else if (currTime < downLoopTime + restTime + upLoopTime)
        {
            transform.position += Vector3.up * upSpeed * Time.deltaTime;
        }
        // staying still at the top for a little
        else if (currTime < downLoopTime + 2*restTime + upLoopTime)
        {
        }
        // reseting the loop
        else
        {
            transform.position = new Vector3(-0.5f, 0, 0);
            currTime = 0f;
        }
    }

    void applySwaying()
    {
        // currTime goes from 0 to downLoopTime we want to convert it to 0 to 2PI
       
        float xOffset = amplitude * Mathf.Sin(currTime * (Mathf.PI / downLoopTime) * frequency) * Time.deltaTime;
        Vector3 Offset = transform.position;
        Offset.x += xOffset;
        transform.position = Offset;
    }
}
