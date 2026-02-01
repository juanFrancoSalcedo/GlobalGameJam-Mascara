using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {  
        if (target != null) 
            transform.position = new Vector3(target.position.x, target.position.y+offset.y, transform.position.z);    
    }
}

