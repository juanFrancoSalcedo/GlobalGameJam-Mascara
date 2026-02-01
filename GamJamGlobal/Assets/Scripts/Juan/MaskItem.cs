using System;
using UnityEngine;
using UnityEngine.Rendering;

public class MaskItem : MonoBehaviour
{
    [SerializeField] MaskType maskType;
    private TriggerDetector2D triggerDetector;
    void Awake()
    {
        triggerDetector = GetComponent<TriggerDetector2D>();
    }

    private void OnEnable() => triggerDetector.OnTriggerEntered += CollectMask;

    private void OnDisable() => triggerDetector.OnTriggerEntered -= CollectMask;

    private void CollectMask(Transform _transform)
    {
        ManagerAudio.Instance.PlayMask();
         MaskManager.Instance.AddMask(this.maskType);
         Destroy(this.gameObject,0.1f);
    }
}

[System.Serializable]
public class MaskModel: ICopy<MaskModel>
{
    public MaskType type;
    public Sprite sptMask;
    public Bullet bullet;
    public GameObject volume;

    public void ActiveSelfVolume(MaskType _type)
    { 
        if(type == _type)
            volume.SetActive(true);
        else
            volume.SetActive(false);
    }

    public MaskModel Copy()
    {
        return (MaskModel)this.MemberwiseClone();
    }
}

public enum MaskType 
{
    None,
    Blue,
    Green,
    Golden,
}
