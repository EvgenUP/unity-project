using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform player;
    public Transform tileParent;

    [Header("Tile data")]
    public GameObject[] tilePrefabs;
    public float tileLength = 10.9f;
    public int visibleTileCount = 10;
    List<GameObject> tiles = new();
    
    int tileCount;
    
    void Start()
    {
        for (int i = 0; i < visibleTileCount; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    void Update()
    {
        if (player.transform.position.z > tileLength * tileCount - (visibleTileCount * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));

            if (tiles.Count > visibleTileCount * 1.25f)
            {
                Destroy(tiles[0]);
                tiles.RemoveAt(0);
            }
        }
    }

    void SpawnTile(int prefabIndex)
    {
        Vector3 spawnPosition = transform.forward * tileLength * tileCount;
        spawnPosition.x -= tilePrefabs[prefabIndex].transform.localScale.x * 1.9f;

        GameObject newObj = Instantiate(tilePrefabs[prefabIndex], spawnPosition, transform.rotation, tileParent);
        tiles.Add(newObj);
        tileCount++;
    }
}
