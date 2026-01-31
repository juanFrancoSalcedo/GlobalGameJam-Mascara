using UnityEngine;


[RequireComponent(typeof(PlayerUpperChecker))]
public class UpperPlatform : MonoBehaviour
{
    [SerializeField] int layerIgnorePlayer;
    [SerializeField] int layerAllowPlayer;
    
    PlayerUpperChecker upperChecker;
    private void Start()
    {
        upperChecker = GetComponent<PlayerUpperChecker>();
    }

    private void Update()
    {
        if (upperChecker.IsPlayerAbove())
            gameObject.layer = layerAllowPlayer;
        else
            gameObject.layer = layerIgnorePlayer;

    }
}
