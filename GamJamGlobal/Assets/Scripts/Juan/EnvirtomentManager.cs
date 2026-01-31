using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnvirtomentManager : MonoBehaviour
{
    [SerializeField] bool isRandom;
    [SerializeField] private List<PlatformSettings> listSettings = new List<PlatformSettings>();
    [SerializeField] private Transform player;
    [SerializeField] private List<PlatformHandler> listInstances = new List<PlatformHandler>();

    private IEnumerator Start() 
    {

        if (isRandom)
        {
            foreach (var setting in listSettings)
            {
                GameObject clonePlatform = Instantiate(listSettings[Random.Range(0,listSettings.Count)].prefab, new Vector3(0, listInstances.Count * 2, 0), Quaternion.identity);
                PlatformHandler handler = clonePlatform.AddComponent<PlatformHandler>();
                listInstances.Add(handler);
                yield return new WaitForEndOfFrame();
            }
        }
        else
        { 
            foreach (var setting in listSettings)
            {
                GameObject clonePlatform = Instantiate(setting.prefab, new Vector3(0, listInstances.Count * 2, 0), Quaternion.identity);
                PlatformHandler handler = clonePlatform.AddComponent<PlatformHandler>();
                listInstances.Add(handler);
                yield return new WaitForEndOfFrame();
            }
        }

    }
}

[System.Serializable]
public struct PlatformSettings 
{
    public GameObject prefab;
}
