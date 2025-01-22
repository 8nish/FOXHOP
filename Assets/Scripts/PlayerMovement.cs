using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float playerspeed;
    [SerializeField] private float playerjump;
    [SerializeField] private LayerMask ground2;
    [SerializeField] private LayerMask wall2;
    private Rigidbody2D body;
    private Animator ani;
    private BoxCollider2D boxc;
    private float walljump2;
    private float XaxisInput;


 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); //grab rigidbody reference
        ani = GetComponent<Animator>(); //grab animator reference
        boxc = GetComponent<BoxCollider2D>(); //grab BoxCollider2D reference

    }
    private void Update()
    {
        XaxisInput = Input.GetAxis("Horizontal");

        //player facing left and right direction
        if(XaxisInput> 0.1f) //right
            transform.localScale = new Vector3(5,5,1); // turn x axis to positive (right)
        else if (XaxisInput < -0.1f) //left
            transform.localScale = new Vector3(-5,5,1); // turn x axis to negative (left)
 

        ani.SetBool("Run", XaxisInput != 0); //RUN IF XaxisInput is not equal to 0 (means arrow is not pressed) and vice versa
        ani.SetBool("Grounded", isGrounded());

        //wall kump
        if(walljump2 > 0.2f)
        {
            body.linearVelocity = new Vector2(XaxisInput * playerspeed, body.linearVelocity.y);

            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;

            if (Input.GetKey(KeyCode.Space))
            Jump();

        }
        
        else walljump2 += Time.deltaTime;
    }

    private void Jump()
    {
        if(isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, playerjump);//move the player upwards with the playerspeed value
            ani.SetTrigger("Jump"); //triggers the jump animation
        }
        else if (onWall() && !isGrounded())
        {   
            if(XaxisInput == 0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 9, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);    
            }
            else
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
           walljump2 = 0;
        }
        
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxc.bounds.center, boxc.bounds.size, 0, Vector2.down, 0.1f, ground2);
        return raycastHit.collider !=null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxc.bounds.center, boxc.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wall2);
        return raycastHit.collider !=null;
    }
    public bool canAttack()
    {
        return XaxisInput == 0 && isGrounded() && !onWall();
    }
}