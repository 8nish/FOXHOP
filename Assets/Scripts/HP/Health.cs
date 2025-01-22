using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float HEALTH1;
    public float HEALTHRN {get; private set; }
    private Animator ani;
    private bool dead;

    private void Awake()
    {
        HEALTHRN = HEALTH1;
        ani = GetComponent<Animator>();
    }

    public void Damage(float _damage)
    {
        HEALTHRN = Mathf.Clamp(HEALTHRN - _damage, 0, HEALTH1);
        
        if (HEALTHRN > 0)
        {
            ani.SetTrigger("hurt");
        }
        else 
        {
            if (!dead)
            ani.SetTrigger("die");

            //player
            if(GetComponent<PlayerMovement>() != null)
                GetComponent<PlayerMovement>().enabled = false;


            //enemy
            if(GetComponent<EnemyPatrol>() != null)
                GetComponent<EnemyPatrol>().enabled = false;

            if (GetComponent<KnightEnemy>() !=null)
                GetComponent<KnightEnemy>().enabled = false;

            dead = true;
        }
    }

    public void Respawn1()
    {
        dead = false;
        HEALTHRN = HEALTH1;
        ani.ResetTrigger("die");
        ani.Play("Idle");
        
        GetComponent<PlayerMovement>().enabled = true;
        
    }

}
