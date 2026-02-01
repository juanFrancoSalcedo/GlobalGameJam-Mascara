using B_Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : Singleton<MaskManager>
{
    [SerializeField] MaskType mask;
    public List<MaskModel> configureMask = new List<MaskModel>();
    MaskModel currentMask = null;
    [SerializeField] private Image imageIcon;
    [SerializeField] private Image[] othersIcons;
    List<MaskModel> collectedMask = new List<MaskModel>();

    private void Start()
    {
        currentMask = configureMask[0];
        collectedMask.Add(currentMask);
        ShowMask();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchMask();
        }
    }

    public void AddMask(MaskType type) 
    {
        if(!collectedMask.Contains(configureMask.First(m => m.type == type)))
            collectedMask.Add(configureMask.FirstOrDefault(m => m.type == type));
        SetMask(type);
        ShowMask();
    }

    public void ShowMask() 
    {
        imageIcon.sprite = currentMask.sptMask;
        othersIcons.ToList().ForEach(i => i.gameObject.SetActive(false));
        collectedMask[0].ActiveSelfVolume(currentMask.type);
        for (int i = 1; i < collectedMask.Count; i++)
        {
            othersIcons[i].sprite = collectedMask[i].sptMask;
            othersIcons[i].gameObject.SetActive(true);
            collectedMask[i].ActiveSelfVolume(currentMask.type);
        }
    }

    public void SetMask(MaskType type) 
    {
        if (collectedMask.Count <= 1)
            return;
        MaskModel last = collectedMask[collectedMask.Count-1];
        collectedMask.Insert(0,last);
        currentMask = collectedMask[0];
        mask = currentMask.type;
        collectedMask.RemoveAt(collectedMask.Count-1);
        Gun.Instance.SetBullet(currentMask.bullet);
        ShowMask();
    }

    public void SwitchMask() 
    {
        if (collectedMask.Count <= 1)
            return;
        MaskModel firstMask = collectedMask[0];
        collectedMask.RemoveAt(0);
        collectedMask.Add(firstMask);
        currentMask = collectedMask[0];
        mask = currentMask.type;
        Gun.Instance.SetBullet(currentMask.bullet);
        ShowMask();
    }

    public MaskType GetMaskType()
    {
        return mask;
    }
}
