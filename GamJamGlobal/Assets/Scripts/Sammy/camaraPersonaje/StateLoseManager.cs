using B_Extensions;
using System.Collections;
using UnityEngine;

public class StateLoseManager : Singleton<StateLoseManager>
{
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] GameObject loseUI;
    public bool Lost = false;
    bool trigger = false; 

    private void Update()
    {
        if (Lost && !trigger)
        {
            StartCoroutine(LoseCoroutine());
        }
    }

    private IEnumerator LoseCoroutine()
    {
        cameraFollow.enabled = false;
        yield return new WaitForSeconds(0.9f);
        loseUI.SetActive(true);
    }
}

