using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    public string respawnPointName = "RespawnPoint";
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered trigger: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            Transform respawn = GameObject.Find("Grid Layout/Start/RespawnPoint").transform;
            
            if (respawn != null)
            {
                other.transform.position = respawn.position;
                other.transform.rotation = respawn.rotation;
            }
        }
    }
}
