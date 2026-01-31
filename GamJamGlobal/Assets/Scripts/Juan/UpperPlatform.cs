using UnityEngine;

public class UpperPlatform : MonoBehaviour
{
    [SerializeField] int layerIgnorePlayer;
    [SerializeField] int layerAllowPlayer;
    [SerializeField] Vector3 positionOffset;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.transform.position.y < transform.position.y)
            gameObject.layer = layerIgnorePlayer;
        else
            gameObject.layer = layerAllowPlayer;

    }
}
