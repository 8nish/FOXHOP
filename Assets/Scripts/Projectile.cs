using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D bcollider;
    private Animator ani;

    private float direction;
    private float bulletkiller;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        bcollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(hit) return;
        float ms = speed * Time.deltaTime * direction;
        transform.Translate(ms, 0, 0);

        bulletkiller += Time.deltaTime;
        if (bulletkiller > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    hit = true;
    bcollider.enabled = false;
    ani.SetTrigger("Hit");

    if(collision.tag =="Enemy")
        collision.GetComponent<Health>().Damage(1.45f);
}


    public void SetDirection(float _direction)
    {
        bulletkiller = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit=false;
        bcollider.enabled=true;

        float ScaleX = transform.localScale.x;
        if (Mathf.Sign(ScaleX) !=_direction)
            ScaleX=-ScaleX;
        
        transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
