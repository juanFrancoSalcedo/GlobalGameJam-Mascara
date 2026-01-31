using System.Collections;
using UnityEngine;

public class BulletDorado : Bullet 
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            StartCoroutine(WaitTeleport());
        }
    }

    protected new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<HPHandler>(out var compo))
        {
            compo.AccessLifeModel().MakeDamageBase();
        }
    }

    private IEnumerator WaitTeleport() 
    {
        yield return new WaitForSeconds(0.1f);
        var playerTag = GameObject.FindFirstObjectByType<DoradoAttack>();

        if (playerTag!= null)
        {
            playerTag.Attack(transform.position);
        }
        Destroy(gameObject,0.2f);
    }
}
