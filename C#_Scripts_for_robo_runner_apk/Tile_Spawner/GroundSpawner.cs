using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundTileprefabs;
    public float zSpawn = 0;
    public float tileLength = 60;
    public int numberOfTiles = 7;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    public void Start()

    {
        for (int i = 0; i < numberOfTiles; i++)
        {

            if (i == 0)

                SpawnTile(0);
            else

                SpawnTile(Random.Range(0, groundTileprefabs.Length));

        }

    }

    public void Update()
    {
        if (playerTransform.position.z - 100 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, groundTileprefabs.Length));
            DeleteTile();
        }

    }




    public void SpawnTile( int tileIndex)

    
    {
        GameObject go = Instantiate (groundTileprefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;


    }

    private void DeleteTile()
    {

     Destroy(activeTiles[0]);
     activeTiles.RemoveAt(0);
        
    }

  }


