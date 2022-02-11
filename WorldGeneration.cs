using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject Player;

    public GameObject chunkEmptyObject;
    public int chunkSize = 10;
    public int renderDistance = 2;
    public int deleteDistance = 3;

//    public Perlin perlin = new Perlin();
    public int octaves = 3;
    public int frequency = 2;
    public float persistance = 0.5f;
    public float scale = 0.01f;
    public int seed = 102938;

    public float landBuffer = 0.1f;
    public float waterLevel = 0.25f;
    public float sandLevel = 0.5f;
    public float dirtLevel = 0.6f;
    public float grassLevel = 0.7f;
    public float darkGrassLevel = 0.8f;
    public float[] layerHeights;

    public GameObject tilePrefab;

    public Texture2D darkGrassTexture;
    public Texture2D grassTexture;
    public Texture2D dirtTexture;
    public Texture2D sandTexture;
    public Sprite waterTexture;

}
