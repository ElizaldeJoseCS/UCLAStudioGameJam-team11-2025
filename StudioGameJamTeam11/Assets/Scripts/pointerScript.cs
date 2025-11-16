using UnityEngine;
using UnityEngine.InputSystem;

public class pointerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            //reloads the scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    void OnJump()
    {
        if (transform.position.y == 1)
        { 
            transform.position = new Vector3(0, 2.5f, 0);
        }
        else
        {
            transform.position = new Vector3(0, 1f, 0);
        }
    }
}
