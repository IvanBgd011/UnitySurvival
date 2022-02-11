using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour
{
    public Movement mov;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            mov.ms = mov.ms = 3;
        }
        Debug.Log("on");
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            mov.ms = mov.ms = 5;
        }
        Debug.Log("off");
    }
}
