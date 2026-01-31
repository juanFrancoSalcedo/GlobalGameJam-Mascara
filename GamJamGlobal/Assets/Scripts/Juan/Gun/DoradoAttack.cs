using UnityEngine;

public class DoradoAttack : MonoBehaviour 
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private LayerMask targetLayer;

    public void Attack(Vector2 newPos)
    {
        transform.position = newPos;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].TryGetComponent<HPHandler>(out var compo))
            {
                compo.AccessLifeModel().MakeDamage(200);
            }

            if (hitColliders[i].TryGetComponent<PlatformHandler>(out var platform))
            { 
                platform.Dead();
            }
        }
    }
}