using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MonoBehaviour
{
    public int seed;
    private int[,] terrainMap;
    private int[,] terrainMapNext;
    private int[,] chunks;
    public Vector3Int tmapSize;


    public Tilemap topMap;
    public Tilemap botMap;
    public Tilemap ForestMap;
    public Tile topTile;
    public Tile botTile;
    public Tile ForestTile;

    int width;
    int height;

    private void Start()
    {
        doSim();
    }
    public void doSim()
    {
        width = tmapSize.x;
        height = tmapSize.y;

        if (terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPos();
        }

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(terrainMap[x,y] == 0)
                {
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
                }
                if (terrainMap[x, y] == 1)
                {
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);

                }
                if (terrainMap[x, y] == 2)
                {
                    ForestMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), ForestTile);
                }


            }
        }

    }

 

    public void initPos()
    {
        for(int x = 0; x<width; x++)
        {
            for(int y = 0; y<height; y++)
            {
                float xC = (float)x / width *15;
                float yC = (float)y / height * 15;
                float noise = Mathf.PerlinNoise(seed + xC, seed +yC);
                if (noise <= 0.4)
                {
                    terrainMap[x, y] = 0;
                }
                if(noise >0.4)
                {
                    terrainMap[x, y] = 1;
                }

            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xC = (float)x / width * 20;
                float yC = (float)y / height * 20;
                float noise = Mathf.PerlinNoise(seed +xC, seed +yC);
                if (noise <= 0.3 && terrainMap[x,y] == 1)
                {
                    terrainMap[x, y] = 2;
                }

            }
        }
    }

    public void clearMap(bool complete)
    {
        topMap.ClearAllTiles();
        botMap.ClearAllTiles();

        if(complete)
        {
            terrainMap = null;
        }
    }
}
