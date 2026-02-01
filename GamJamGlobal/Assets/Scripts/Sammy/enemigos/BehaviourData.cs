using System;
using UnityEngine;

[Serializable]
public class BehaviourData
{
    [SerializeField] GameObject _visual;
    [SerializeField] float _speed;

    public GameObject Visual { get => _visual; set => _visual = value; }
    public float Speed { get => _speed; set => _speed = value; }

}
