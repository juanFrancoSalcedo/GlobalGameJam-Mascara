using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField] protected float timeLife = 2f;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected ImpactEffect impact;
    Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeLife);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<HPHandler>(out var compo))
        { 
            print(other.name);
            compo.AccessLifeModel().MakeDamageBase();
        }

        Instantiate(impact,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    public void Shot(Vector2 direction, float shotSpeed)
    {
        Vector2 dir = direction;
        if (dir == Vector2.zero) 
            dir = Vector2.right;

        rb.linearVelocity = dir.normalized * shotSpeed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
