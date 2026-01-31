using System;
using UnityEngine;

public class HPHandler : MonoBehaviour
{
    [SerializeField] LifePlatformData data;

    LifeModel lifeModel;

    public LifeModel AccessLifeModel() => lifeModel;

    public void Awake()
    {
        lifeModel = new LifeModel(data.hp, WaitDead);
    }

    private void WaitDead()
    {
        if(TryGetComponent<Rigidbody2D>(out var compo))
            compo.SetRotation(120f);

        if (TryGetComponent<Collider2D>(out var component))
            component.enabled = false;

        if (TryGetComponent<terrestre>(out var terrestre))
            terrestre.enabled = false;
        Destroy(gameObject, 0.3f);
    }

}


