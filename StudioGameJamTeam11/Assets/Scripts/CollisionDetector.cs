using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private bool isTouching = false;
    private bool shouldDestroy = false;

    void OnTriggerStay2D(Collider2D other)
    {
        // check the tag of the gameobject
        if (other.gameObject.CompareTag("Target"))
        {
            isTouching = true;
            if (shouldDestroy)
                Destroy(other.gameObject);
            shouldDestroy = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            isTouching = false;
        }
    }

    public bool IsTouching()
    { 
        return isTouching;
    }

    public void Destroy()
    {
        shouldDestroy = true;
    }
}
