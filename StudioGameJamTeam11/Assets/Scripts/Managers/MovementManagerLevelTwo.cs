using UnityEngine;

public class MovementManagerLevelTwo : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-speed * Time.fixedDeltaTime, 0, 0);
    }
}
