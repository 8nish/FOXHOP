using UnityEngine;

public class KnightEnemy : MonoBehaviour
{
    [SerializeField] private float CD; 
    [SerializeField] private float damage; 
    [SerializeField] private BoxCollider2D boxc; 
    [SerializeField] private LayerMask player; 
    [SerializeField] private float range; 
    [SerializeField] private float colliderdistance; 
    private Animator ani;

    private Health playerHealth;
    private float CDTimer = Mathf.Infinity; 
    private EnemyPatrol enemypatrol; 

    private void Awake()
    {
        ani = GetComponent<Animator>(); // Get Animator component
        enemypatrol = GetComponentInParent<EnemyPatrol>(); // Get EnemyPatrol script
    }

    private void Update()
    {
        CDTimer += Time.deltaTime; //update cooldown timer

        if (PlayerInSight()) //check if the player is in sight
        {
            if (CDTimer >= CD) //check if cooldown is complete
            {
                CDTimer = 0; //reset cooldown
                ani.SetTrigger("meleeAtack"); //trigger attack animation
            }
        }

        // Enable or disable patrol based on player presence
        if (enemypatrol != null)
            enemypatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        //check for player with boxcast
        RaycastHit2D hit = Physics2D.BoxCast(
            boxc.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
            new Vector3(boxc.bounds.size.x * range, boxc.bounds.size.y, boxc.bounds.size.z),
            0, Vector2.left, 0, player);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>(); // get players health

        return hit.collider != null; //return true if player is detected
    }

    private void OnDrawGizmos()
    {
        //visualize attack range in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxc.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
            new Vector3(boxc.bounds.size.x * range, boxc.bounds.size.y, boxc.bounds.size.z));
    }

    private void damageplayer()
    {
        if (PlayerInSight()) //check if player is in sight
        {
            playerHealth.Damage(damage); //deal damage to the player
        }
    }
}
