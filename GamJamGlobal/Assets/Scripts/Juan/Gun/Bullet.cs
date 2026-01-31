using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField] private float timeLife = 2f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private ImpactEffect impact;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeLife);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impact,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    public void Shot(Vector2 direction, float shotSpeed)
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        Vector2 dir = direction;
        if (dir == Vector2.zero) dir = Vector2.right;

        rb.linearVelocity = dir.normalized * shotSpeed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}