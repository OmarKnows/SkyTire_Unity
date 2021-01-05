using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform player;
    public float spawnLocation = 0;
    public float tileLength = 30;
    public int n = 5;

    private List<GameObject> spawnedTiles = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < n; i++)
        {
            if (i == 0) SpawnTile(0); //first tile spawned is tile 0 (empty tile with no obstacles)
            else SpawnTile(Random.Range(0, tilePrefabs.Length)); //spawn n initial tiles
        }
    }

    private void Update()
    {
        if(player.position.z - 35 > spawnLocation - n*tileLength) //after player finishes tile
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length)); //spawn another tile
            DeleteTile(); //delete finished tile
        }
    }

    private void SpawnTile(int i)
    {
        GameObject tile = Instantiate(tilePrefabs[i], transform.forward * spawnLocation, transform.rotation); //create tile at spawn location
        spawnedTiles.Add(tile);
        spawnLocation += tileLength; //update spawn location
    }

    private void DeleteTile()
    {
        Destroy(spawnedTiles[0]);
        spawnedTiles.RemoveAt(0);
    }

}
