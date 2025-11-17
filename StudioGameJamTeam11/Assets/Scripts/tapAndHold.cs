using UnityEngine;
using UnityEngine.InputSystem;

public class tapAndHold : MonoBehaviour
{
    bool validTarget = false;
    bool destory = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnJump()
    {
        if (validTarget)
        {
            destory = true; ;
        }
        else 
        {
            Debug.Log("missed");
        }
    }

    void OnReleaseButton()
    { 
        Debug.Log("released");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        validTarget = true;
        if(destory)
        {
            Destroy(other.gameObject);
            destory = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        validTarget = false;
    }
}
