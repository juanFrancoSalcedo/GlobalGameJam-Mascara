using System.Collections;
using UnityEngine;


[RequireComponent(typeof(PlayerUpperChecker))]
public class PlatformHandler: MonoBehaviour
{
    [SerializeField] LifePlatformData data;
    CollisionDetector2D collisionDetector;
    LifeModel lifePlatform;
    [SerializeField] private ParticleSystem particles;
    PlayerUpperChecker upperChecker;
    private void Start()
    {
        upperChecker = GetComponent<PlayerUpperChecker>();
    }

    private void Awake()
    {
        lifePlatform = new LifeModel(data.hp,Dead);
        collisionDetector = GetComponent<CollisionDetector2D>();
    }

    private void OnEnable()
    {
        collisionDetector.OnCollisionEntered += StartDamage;
        collisionDetector.OnCollisionExited += StopDamage;
    }

    private void OnDisable()
    {
        collisionDetector.OnCollisionEntered -= StartDamage;
        collisionDetector.OnCollisionExited -= StopDamage;
    }
    private void StopDamage(Collision2D d)
    {
        if (damageCoroutine != null)
            StopCoroutine(damageCoroutine);
    }

    private void StartDamage(Collision2D d)
    {
        if (!upperChecker.IsPlayerAbove())
            return;
        StopDamage(d);
        damageCoroutine = StartCoroutine(DoDamage());
    }

    Coroutine damageCoroutine;
    private IEnumerator DoDamage() 
    {
        while (!lifePlatform.IsDead)
        { 
            lifePlatform.MakeDamageBase();
            particles.Play();
            yield return new WaitForSeconds(1f);
        }
        damageCoroutine = null;
    }

    public void Dead() 
    {
        //Improve this
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public struct LifePlatformData 
{
    public int hp;
}
