using DG.Tweening;
using System;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [SerializeField] GameObject panelLost;
    [SerializeField] Transform playerImage;
    [SerializeField] private int finishY;

    void OnEnable()
    {
        EventBus.Instance.Susbscribe(EventGlobalType.Lost,ShowPanel);
    }

    private void OnDisable()
    {
        EventBus.Instance.Unsusbscribe(EventGlobalType.Lost);
    }

    private void ShowPanel()
    {
        panelLost.SetActive(true);
    }

    private void AnimateFinish() 
    {
        //player.DOLocalMoveY(0);
    }
}
