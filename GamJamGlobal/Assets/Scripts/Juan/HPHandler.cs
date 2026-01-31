using System;
using UnityEngine;

public class HPHandler : MonoBehaviour
{
    [SerializeField] LifePlatformData data;

    LifeModel lifeModel;

    public LifeModel AccessLideModel() => lifeModel;

    public void Awake()
    {
        lifeModel = new LifeModel(data.hp, Dead);
    }

    private void Dead()
    {
        if(TryGetComponent<Rigidbody2D>(out var compo))
            compo.SetRotation(120f);

        if (TryGetComponent<Collider2D>(out var component))
            component.enabled = false;
    }
}


