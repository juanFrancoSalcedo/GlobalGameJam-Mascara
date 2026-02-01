using UnityEngine;

public class GoalMask : MonoBehaviour
{
    [SerializeField] GameObject panelWin;
    TriggerDetector2D trigger;


    private void Awake()
    {
        trigger = GetComponent<TriggerDetector2D>();
    }
    private void OnEnable()
    {
        EventBus.Susbscribe(EventGlobalType.Win,ShowWin);
        trigger.OnTriggerEntered += (t)=>EventBus.Instance.Invoke(EventGlobalType.Win);
    }

    private void OnDisable()
    {
        EventBus.Unsusbscribe(EventGlobalType.Win);
        trigger.OnTriggerEntered -= (t) => EventBus.Instance.Invoke(EventGlobalType.Win);
    }

    private void ShowWin() 
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }
}
