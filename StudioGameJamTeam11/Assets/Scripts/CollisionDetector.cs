using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private bool isTouching = false;
    private bool shouldDestroy = false;
    private int degree;

    [SerializeField] GameObject targetPrefab;

    void OnTriggerStay2D(Collider2D other)
    {
        // check the tag of the gameobject
        if (other.gameObject.CompareTag("Target"))
        {
            isTouching = true;
            if (shouldDestroy)
            {
                Destroy(other.gameObject);
                placeNewTarget();
            }
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

    public void setDegree(int input)
    {
        degree = input;
    }

    void placeNewTarget()
    {
        GameObject newPrefabInstance = Instantiate(targetPrefab, new Vector3(0,-1,0), Quaternion.Euler(0,0,90));
        float randDegree = Random.Range(degree, -1 * degree);
        newPrefabInstance.transform.RotateAround(new Vector3(0, 4, 0), new Vector3(0, 0, 1), randDegree);
    }
}
