using System;
using System.Collections;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField] Transform shoulder;
    [SerializeField] Camera cam;
    [SerializeField] float rotationOffset = 0f;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Vector3 offsetLeft;
    [SerializeField] Vector3 offsetRigth;

    [SerializeField] Personaje personaje;
    private void Awake()
    {
        //transform.SetParent(null);
    }

    void Update()
    {
        spriteRenderer.sortingOrder = (shoulder.localScale.x<0)?-1:3;
        transform.position = shoulder.position;

        if (cam == null)
            cam = Camera.main;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;

        Vector3 dir = mouseWorld - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + rotationOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        float screenCenterX = Screen.width / 2f;
        spriteRenderer.flipY = Input.mousePosition.x < screenCenterX;
    }
}
