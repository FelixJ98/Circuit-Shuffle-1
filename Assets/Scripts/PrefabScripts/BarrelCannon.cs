using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BarrelCannon : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootForce = 10f;
    public float Despawn = 10f;
    public float shootInt = 2f; // Time between shots
    
    private float FireRate;
    
    void Start()
    {
        FireRate = Time.time;
    }
    
    void Update()
    {
        // Shoot automatically at intervals
        if (Time.time >= FireRate + shootInt)
        {
            Shoot();
            FireRate = Time.time;
        }
    }
    
    public void Shoot()
    {
        if (projectilePrefab == null || firePoint == null) return;
        
        // Spawn the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        // Add force to make it move
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);
        }
        
        // Delete after specified time
        Destroy(projectile, Despawn);
    }
}
