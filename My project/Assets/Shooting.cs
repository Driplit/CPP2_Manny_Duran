using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public LookAtPlayer look;
    public float shootInterval = 20f; // Fire every 20 seconds

    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootInterval); // Start shooting every 20 sec
    }

    void Shoot()
    {
        if (!look.Spotted)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Debug.Log("Bullet Fired!");
        }
        else
        {
            Debug.Log("Spotter no bullet fired!");
        }
    }
}