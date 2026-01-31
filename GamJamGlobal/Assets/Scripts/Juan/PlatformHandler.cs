using System;
using System.Collections;
using UnityEngine;

public class PlatformHandler: MonoBehaviour
{
    [SerializeField] LifePlatformData data;
    CollisionDetector2D collisionDetector;
    LifePlatform lifePlatform;
    [SerializeField] private ParticleSystem particles;

    private void Awake()
    {
        lifePlatform = new LifePlatform(data.hp,Dead);
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
            yield return new WaitForSeconds(0.9f);
        }
        damageCoroutine = null;
    }

    public void Dead() 
    {
        //Improve this
        gameObject.SetActive(false);
    }
}

public class LifePlatform
{
    public int hp;
    public Action onDead;

    public LifePlatform(int hp, Action onDead)
    {
        this.hp = hp;
        this.onDead = onDead;
    }

    public void MakeDamageBase()
    {
        hp --;
        CheckDead();
    }

    public bool IsDead => hp <=0;
    public bool CheckDead() 
    {
        if (IsDead)
        {
            onDead?.Invoke();
            return true;
        }
        return false;
    }
}

[System.Serializable]
public struct LifePlatformData 
{
    public int hp;
}
