using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    GameObject player;
    TriggerDetector2D triggerDetector;
    [SerializeField] private float yOffset = -2f;
    private Camera mainCamera;
    private float maxYPosition;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        maxYPosition = transform.position.y;
        triggerDetector= GetComponent<TriggerDetector2D>();
    }

    void OnEnable()
    {
        triggerDetector.OnTriggerEntered += MakeLose;
    }
    private void OnDisable()
    {
        triggerDetector.OnTriggerEntered -= MakeLose;
    }

    private void MakeLose(Transform transform)
    {
        print("Lose");
    }

    private void Update()
    {
        float cameraYPosition = mainCamera.transform.position.y + yOffset;
        
        if (cameraYPosition > maxYPosition)
        {
            maxYPosition = cameraYPosition;
            transform.position = new Vector3(transform.position.x, maxYPosition, transform.position.z);
        }
    }

}
