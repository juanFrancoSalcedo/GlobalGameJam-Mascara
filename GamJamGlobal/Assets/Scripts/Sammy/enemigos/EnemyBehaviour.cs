using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Volador))]
public class EnemyBehaviour:MonoBehaviour
{
    [SerializeField] BehaviourData dataPassive;
    [SerializeField] BehaviourData dataNormal;
    [SerializeField] BehaviourData dataAgressive;
    [SerializeField] MaskType mineMask;
    Volador volador;
    private void Start()
    {
        volador = GetComponent<Volador>();
    }


    public void CheckBehaviour(MaskType playerType) 
    {
        var predicateDictionary = new Dictionary<Predicate<MaskType>, Action>();
        predicateDictionary.Add((pMask)=> pMask == MaskType.Blue  && mineMask == MaskType.Green ,Aggressive);
        predicateDictionary.Add((pMask) => pMask == MaskType.Green && mineMask == MaskType.Blue, Aggressive);
        predicateDictionary.Add((pMask) => pMask == MaskType.Blue && mineMask == MaskType.Blue, Passive);
        predicateDictionary.Add((pMask) => pMask == MaskType.Green && mineMask == MaskType.Green, Passive);
        predicateDictionary.Add((pMask) => pMask == MaskType.None || mineMask == MaskType.None, Normal);

        foreach (var predicate in predicateDictionary) 
        {
            if (predicate.Key(playerType))
            {
                predicate.Value();
                break;
            }
        }
    }

    public void Passive()
    {
        dataNormal.Visual.SetActive(false);
        dataAgressive.Visual.SetActive(false);
        volador.velocidadMovimiento = dataPassive.Speed;
        dataPassive.Visual.SetActive(true);
    }

    public void Normal()
    {
        dataAgressive.Visual.SetActive(false);
        dataPassive.Visual.SetActive(false);
        volador.velocidadMovimiento = dataNormal.Speed;
        dataNormal.Visual.SetActive(true);
    }

    public void Aggressive()
    {
        dataNormal.Visual.SetActive(false);
        dataPassive.Visual.SetActive(false);
        volador.velocidadMovimiento = dataAgressive.Speed;
        dataAgressive.Visual.SetActive(true);
    }
}
