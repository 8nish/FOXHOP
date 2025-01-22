using UnityEngine;

public class SAWTB : MonoBehaviour
{
    [SerializeField] private float damage; 
    [SerializeField] private float speed; 
    [SerializeField] private float movement; 
    private bool moveDown; 
    private float top; 
    private float bottom; 

    private void Awake()
    {
        // Set movement boundaries
        top = transform.position.y + movement;
        bottom = transform.position.y - movement;
        moveDown = true; // Start moving down
    }

    private void Update()
    {
        if (moveDown)
        {
            // Move down
            if (transform.position.y > bottom)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y - speed * Time.deltaTime,
                    transform.position.z
                );
            }
            else
            {
                moveDown = false; // Change direction to up
            }
        }
        else
        {
            // Move up until reaching the top boundary
            if (transform.position.y < top)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + speed * Time.deltaTime,
                    transform.position.z
                );
            }
            else
            {
                moveDown = true; // Change direction to down
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides, deal damage
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().Damage(damage);
        }
    }
}
