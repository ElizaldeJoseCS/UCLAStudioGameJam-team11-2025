using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    public float speed = 120f; // degrees per second

    void Update()
    {
        // Rotate clockwise (negative Z)
        transform.Rotate(0, 0, -speed * Time.deltaTime);
    }
}