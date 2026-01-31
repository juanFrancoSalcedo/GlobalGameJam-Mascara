using UnityEngine;

public class ImpactEffect : MonoBehaviour 
{
    [SerializeField] private float timeLife = 2f;
    [SerializeField] private ParticleSystem effect;
    private void Start()
    {
        Destroy(gameObject, timeLife);
        effect.Play();
    }
}