using System;
using System.Collections;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField] Transform shoulder;
    [SerializeField] Camera cam;
    [SerializeField] float rotationOffset = 0f;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Awake()
    {
        transform.SetParent(null);
    }

    void Update()
    {
        spriteRenderer.sortingOrder = (shoulder.localScale.x<0)?-1:3;

        if (shoulder != null)
            transform.position = shoulder.position;

        if (cam == null) 
            cam = Camera.main;
        if (cam == null) 
            return;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;

        Vector3 dir = mouseWorld - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + rotationOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
