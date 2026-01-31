using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerUpperChecker))]
public class PlatformHandler : MonoBehaviour
{
    [SerializeField] LifePlatformData data;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private List<Animator> animators = new List<Animator>();
    CollisionDetector2D collisionDetector;
    LifeModel lifePlatform;
    PlayerUpperChecker upperChecker;
    private void Start()
    {
        upperChecker = GetComponent<PlayerUpperChecker>();
    }

    private void Awake()
    {
        lifePlatform = new LifeModel(data.hp, WaitDisableCollision);
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
        animators.ForEach(a => a.SetBool("Damage", false));
        animators.ForEach(a => a.SetBool("Fall", false));
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
            animators.ForEach(a => a.SetBool("Damage",true));
            yield return new WaitForSeconds(1f);
        }
        damageCoroutine = null;
    }

    #region Fall Animation
    private void WaitDisableCollision() => Invoke(nameof(WaitDead), 0.7f);

    private void WaitDead() 
    {
        animators.ForEach(a => a.SetBool("Fall", true));
        Invoke(nameof(Dead),1.2f);
    }
    public void Dead() => gameObject.SetActive(false);
    #endregion
}

[System.Serializable]
public struct LifePlatformData 
{
    public int hp;
}
