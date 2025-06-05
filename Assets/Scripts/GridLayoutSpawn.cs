using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLayoutSpawn : MonoBehaviour
{
    [Header("Grid Points")]
    public Transform[] spawnPoints;
    
    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs;
    
    [Header("Plain Platform Prefab")]
    public GameObject platformPrefab;
    
    public void SpawnRandomObstacles()
    {
        ClearGrid();
        ShowAllGridCubes();
        
        // Pick 8 random spawn points for obstacles
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            availableIndices.Add(i);
        }
        
        // Spawn 8 random obstacles
        for (int i = 0; i < 8 && availableIndices.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, availableIndices.Count);
            int spawnIndex = availableIndices[randomIndex];
            availableIndices.RemoveAt(randomIndex);
            
            GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            
            Instantiate(randomObstacle, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            
            if (spawnPoints[spawnIndex].parent != null)
            {
                spawnPoints[spawnIndex].parent.gameObject.SetActive(false);
            }
        }
        // Fill remaining spots with platforms
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (availableIndices.Contains(i))
            {
                Instantiate(platformPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
                
                if (spawnPoints[i].parent != null)
                {
                    spawnPoints[i].parent.gameObject.SetActive(false);
                }
            }
        }
    }
    
    void ClearGrid()
    {
        // Find and destroy all spawned obstacles
        GameObject[] spawned = GameObject.FindGameObjectsWithTag("Spawned");
        for (int i = 0; i < spawned.Length; i++)
        {
            DestroyImmediate(spawned[i]);
        }
    }
    
    void ShowAllGridCubes()
    {
        // Turn on grid cubes
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].parent != null)
            {
                spawnPoints[i].parent.gameObject.SetActive(true);
            }
        }
    }
}
