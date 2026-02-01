using UnityEngine;


public class PlayerUpperChecker : MonoBehaviour 
{
    [SerializeField] Vector3 positionOffset;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool IsPlayerAbove()
    {
        if (player == null) 
            return false;

        return transform.position.y + positionOffset.y < player.transform.position.y;
    }
}