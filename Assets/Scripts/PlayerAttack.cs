using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attack2;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator ani;
    private PlayerMovement playerMovement;
    private float cooldown = 1000f;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldown > attack2 && playerMovement.canAttack())
            Attack();

        cooldown += Time.deltaTime;
    }

    private void Attack()
    {
        ani.SetTrigger("Attack");
        cooldown = 0;

        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}