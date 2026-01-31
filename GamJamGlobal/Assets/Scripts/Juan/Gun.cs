using UnityEngine;

public class Gun : MonoBehaviour 
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private ParticleSystem muzzle;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float timeReload = 1f;




    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Shot();
        }
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