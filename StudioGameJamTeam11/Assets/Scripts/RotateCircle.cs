using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    public float speed = 120f; // degrees per second

    private bool rotating = false;

    void Update()
    {
        // Rotate clockwise (negative Z)
        if (rotating)
            transform.Rotate(0, 0, -speed * Time.deltaTime);
    }

    public void StartRotation()
    {
        rotating = true;
    }
}