using UnityEngine;

public class BulletVerde : Bullet 
{

    int countBounces = 0;
    protected new void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<HPHandler>(out var compo))
        {
            compo.AccessLifeModel().MakeDamageBase();
            DestroyItself();
        }
        else 
        {
            countBounces++;
            if (countBounces < 3)
            { 
                Vector2 currentVelocity = GetComponent<Rigidbody2D>().linearVelocity;
                Vector2 reflectedDirection = Vector2.Reflect(currentVelocity.normalized, Vector2.up);
                GetComponent<Rigidbody2D>().linearVelocity = reflectedDirection * currentVelocity.magnitude;
                float angle = Mathf.Atan2(reflectedDirection.y, reflectedDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
                DestroyItself();
        }
    }

    private void DestroyItself()
    {
        Instantiate(impact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
