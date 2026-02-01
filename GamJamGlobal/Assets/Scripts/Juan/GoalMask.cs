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
        EventBus.Instance.Susbscribe(EventGlobalType.Win,ShowWin);
        trigger.OnTriggerEntered += (t)=>EventBus.Instance.Invoke(EventGlobalType.Win);
    }

    private void OnDisable()
    {
        EventBus.Instance.Unsusbscribe(EventGlobalType.Win);
        trigger.OnTriggerEntered -= (t) => EventBus.Instance.Invoke(EventGlobalType.Win);
    }

    private void ShowWin() 
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }
}
