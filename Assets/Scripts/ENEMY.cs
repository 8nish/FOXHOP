using UnityEngine;

public class ENEMY : MonoBehaviour
{
    [SerializeField] private float ATTACKCD;
    [SerializeField] private float RANGE;
    [SerializeField] private float DISTANCE;

    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxc;
    [SerializeField] private LayerMask Player;
    private Health PLAYERHEALTH;

    private Animator ani;
    private float CDTIMER = Mathf.Infinity;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }


    private void Update()
    {
        CDTIMER += Time.deltaTime;

        // Attack
        if (PlayerInSight())
        {
            if (CDTIMER >= ATTACKCD)
            {
                // Perform attack
                CDTIMER = 0; // Reset cooldown timer after attack
                ani.SetTrigger("attack");
            }
        }
    }

    private bool PlayerInSight()
{
    Vector3 scaledSize = new Vector3(boxc.bounds.size.x * RANGE, boxc.bounds.size.y, boxc.bounds.size.z);
    RaycastHit2D hit = Physics2D.BoxCast(
        boxc.bounds.center + transform.right * RANGE * transform.localScale.x * DISTANCE,
        new Vector2(scaledSize.x, scaledSize.y), // Use Vector2 for size
        0, 
        Vector2.left, 
        0, 
        Player
    );

    if(hit.collider !=null)
        PLAYERHEALTH =hit.transform.GetComponent<Health>();

    return hit.collider != null;
}

    private void DamagePlayer()
{
    if (PLAYERHEALTH != null)
    {
        PLAYERHEALTH.Damage(damage);
    }
}


    private void OnDrawGizmos()
    {
        if (boxc != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxc.bounds.center + transform.right * RANGE * transform.localScale.x * DISTANCE,
            new Vector3(boxc.bounds.size.x * RANGE, boxc.bounds.size.y, boxc.bounds.size.z) 
            );           
        }
    }
}
