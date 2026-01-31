using System;
using System.Collections;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Camera cam;
    [SerializeField] float rotationOffset = 0f;

    void Update()
    {
        if (player != null)
            transform.position = player.position;

        if (cam == null) cam = Camera.main;
        if (cam == null) return;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;

        Vector3 dir = mouseWorld - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + rotationOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
