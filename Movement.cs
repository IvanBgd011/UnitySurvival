using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FixedJoystick js;
    [SerializeField] public float ms;

    Vector2 move, str;
    private void FixedUpdate()
    {

        move = new Vector2(js.Horizontal, js.Vertical);

        rb.velocity = new Vector2(move.x * ms, move.y * ms);
        if (move != Vector2.zero)
        {
            transform.up = move;
        }


    }
}


