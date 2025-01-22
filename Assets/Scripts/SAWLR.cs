using UnityEngine;

public class SAWLR : MonoBehaviour //same as sawtb but left to right
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movement;
    private bool moveLeft;
    private float left;
    private float right;

    private void Awake()
    {
        left = transform.position.x - movement;
        right = transform.position.x + movement;
        moveLeft = true;
    }

    private void Update()
    {
        if (moveLeft)
        {
            if (transform.position.x > left)
            {
                transform.position = new Vector3(
                    transform.position.x - speed * Time.deltaTime, 
                    transform.position.y, 
                    transform.position.z
                );
            }
            else
            {
                moveLeft = false;
            }
        }
        else
        {
            if (transform.position.x < right)
            {
                transform.position = new Vector3(
                    transform.position.x + speed * Time.deltaTime, 
                    transform.position.y, 
                    transform.position.z
                );
            }
            else
            {
                moveLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().Damage(damage);
        }
    }
}
