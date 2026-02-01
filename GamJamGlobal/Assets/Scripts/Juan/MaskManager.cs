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
        ShowMask();
    }

    public void ShowMask() 
    {
        imageIcon.sprite = currentMask.sptMask;
        othersIcons.ToList().ForEach(i => i.gameObject.SetActive(false));

        for (int i = 1; i < collectedMask.Count; i++)
        {
            othersIcons[i].sprite = collectedMask[i].sptMask;
            othersIcons[i].gameObject.SetActive(true);
        }
    }

    public void SwitchMask() 
    {
        if (collectedMask.Count <= 1)
            return;

        MaskModel firstMask = collectedMask[0];
        collectedMask.RemoveAt(0);
        collectedMask.Add(firstMask);
        currentMask = collectedMask[0];
        ShowMask();
    }

    public MaskType GetMaskType()
    {
        return mask;
        //return currentMask.type;
    }
}
