using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mergeable : MonoBehaviour
{
    private int count = 0;
    private bool dropped = false;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (dropped)
        {
            dropped = true;
        }
        else
        {
            dropped = false;
        }
        if (!dropped)
        {
            transform.position = Dropper.pos + new Vector2(0, -1);
            rb.gravityScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dropped = true;
                rb.gravityScale = 1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            count++;
            if (count == 1)
            {
                Destroy(gameObject);
            }
        }
    }

}
