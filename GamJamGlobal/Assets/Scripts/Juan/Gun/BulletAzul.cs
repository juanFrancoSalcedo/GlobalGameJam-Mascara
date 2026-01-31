using UnityEngine;

public class BulletAzul : Bullet 
{
    protected new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<HPHandler>(out var compo))
        {
            compo.AccessLifeModel().MakeDamageBase();
            DestroyItself();
        }
    }

    private void DestroyItself()
    {
        Instantiate(impact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}