using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
    public int sizeX, sizeY; // number of tiles generated
    public float f; // this variable changes "sharpness" of the output tilemap, keep it above 10 for best result
    public GameObject[] Prefabs; // tile prefabs

    /// <summary>
    /// Working Perlin Noise Terrain Generator
    /// </summary>
    /// Perlin Noise generator is working as intended, it just needs premade sprites for biome borders
    /// aside that, its working pretty much as intended
    /// 


    public void Start() {
        GenerateTerrain();
    }

    private void GenerateTerrain() {
        for (int x = 0+(int)transform.position.x; x < sizeX+ (int)transform.position.x; x++) {
            for (int y = 0+ (int)transform.position.y; y < sizeY+ (int)transform.position.y; y++) {
                //GameObject currentPrefab;
                //if (Mathf.PerlinNoise(x/f, y /f) >= 0.5f)
                //    currentPrefab = Prefabs[0];
                //else currentPrefab = Prefabs[1];
                GameObject instance = Instantiate(Prefabs[1], transform);
                instance.transform.position = new Vector2(x, y);
                instance.GetComponent<SpriteRenderer>().color = new Color(Mathf.PerlinNoise(x / f, y / f), .5f, .5f);
            }
        }
    }
}
