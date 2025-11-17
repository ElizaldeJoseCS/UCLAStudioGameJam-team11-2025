using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] GameObject tapper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hide();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= 5)
        {
            show();
        }
        // if the target goes off screen to the left, delete it and update (the score and also create a new target)
        if (transform.position.y <= -5)
        {
            deleteAndUpdate();
        }
    }
    void deleteAndUpdate()
    {
        // update the score
        tapper.GetComponent<tapAndHold>().targetMissed();
        // delete this target
        Destroy(gameObject);
    }

    void hide()
    {
        Color color = spriteRenderer.color;
        color.a = 0f; // Set alpha to 0 (fully transparent)
        spriteRenderer.color = color;
    }

    void show()
    {
        Color color = spriteRenderer.color;
        color.a = 1f; // Set alpha to 1 (fully opaque)
        spriteRenderer.color = color;
    }

}
