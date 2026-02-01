using B_Extensions;
using UnityEngine;

public class Gun : Singleton<Gun> 
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private ParticleSystem muzzle;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float timeReload = 1f;
    

    float sumTime =0;
    private void Update()
    {
        sumTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && sumTime>=timeReload) 
        {
            Shot();
            sumTime = 0;
        }
    }

    public void SetBullet(Bullet newBullet) 
    {
        bulletPrefab = newBullet;
    }

    public void Shot()
    {
        Vector3 spawnPos = (muzzle != null) ? muzzle.transform.position : transform.position;
        Quaternion spawnRot = transform.rotation;
        muzzle.Play();
        Bullet b = Instantiate(bulletPrefab, spawnPos, spawnRot);
        b.Shot(transform.right, bulletSpeed);
    }
}