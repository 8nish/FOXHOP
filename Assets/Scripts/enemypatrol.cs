using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge; 
    [SerializeField] private Transform rightEdge; 

    [Header("Enemy")]
    [SerializeField] private Transform enemy; 
    [Header("Movement Parameters")]
    [SerializeField] private float speed; 
    private Vector3 initScale; 
    private bool movingLeft;
    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration; 
    private float idleTimer; 

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim; 

    private void Awake()
    {
        initScale = enemy.localScale; //store initial scale
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false); //stop moving animation when disabled
    }

    private void Update()
    {
        if (movingLeft) //check if moving left
        {
            if (enemy.position.x >= leftEdge.position.x) //check if within left limit
                MoveInDirection(-1); //move left
            else
                DirectionChange(); //change direction
        }
        else // Moving right
        {
            if (enemy.position.x <= rightEdge.position.x) //check if within right limit
                MoveInDirection(1); //cove right
            else
                DirectionChange(); //change direction
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false); //stop moving animation
        idleTimer += Time.deltaTime; //increment idle timer

        if (idleTimer > idleDuration) //check if idle duration has passed
            movingLeft = !movingLeft; //switch direction
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0; //reset idle timer
        anim.SetBool("moving", true); // start moving animation

        // make enemy face the moving direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        // move enemy in the specified direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
