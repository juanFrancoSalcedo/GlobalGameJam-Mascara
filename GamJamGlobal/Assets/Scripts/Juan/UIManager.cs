using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject panelLost;

    void OnEnable()
    {
        EventBus.Susbscribe(EventGlobalType.Lost,ShowPanel);
    }

    private void OnDisable()
    {
        EventBus.Unsusbscribe(EventGlobalType.Lost);
    }

    private void ShowPanel()
    {
        panelLost.SetActive(true);
    }
}
