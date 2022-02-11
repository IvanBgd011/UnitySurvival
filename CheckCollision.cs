using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool rockbool = false;
    public bool treebool = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "rock")
        {
            Debug.Log("rock+");
            rockbool = true;
        }
        else if (col.gameObject.tag == "tree")
        {
            Debug.Log("tree+");
            treebool = true;
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "rock")
        {
            Debug.Log("rock-");
            rockbool = false;
        }
        else if (col.gameObject.tag == "tree")
        {
            Debug.Log("tree-");
            treebool = false;
        }
    }
}
