using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] int count =0;
    [SerializeField] float gap = 1f;
    [SerializeField] private List<PlatformSettings> listSettings = new List<PlatformSettings>();
    [SerializeField] private Transform player;
    private List<GameObject> listInstances = new List<GameObject>();

    float startedPosition = 0;

    private IEnumerator Start() 
    {
        startedPosition = transform.position.y;
        for (int i = 0; i < count; i++)
        {
            //easier to player
            if(i<10)
                CreateRandom(listSettings[Random.Range(0, 2)]);
            else if(i>40)
                CreateRandom(listSettings[Random.Range(2, listSettings.Count)]);
            else
                CreateRandom(listSettings[Random.Range(0, listSettings.Count)]);

            yield return new WaitForEndOfFrame();
        }
    }

    private void CreateRandom(PlatformSettings settings)
    {
        GameObject clonePlatform = Instantiate(settings.prefab, new Vector3(0,PosZ, 0), Quaternion.identity);
        listInstances.Add(clonePlatform);
    }

    private float PosZ => startedPosition + (listInstances.Count * gap);
}

[System.Serializable]
public struct PlatformSettings 
{
    public GameObject prefab;
}