using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public GameObject Item;

    private Vector2 center;
    private Vector3 size;
    public int StartSpawn;
    public GameObject spawnable;


    private void Start()
    {
        size = spawnable.transform.localScale;
        center = spawnable.transform.position;

        for (int i = 0; i < StartSpawn; i++)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));

        Instantiate(Item, pos, Quaternion.identity);

    }


}