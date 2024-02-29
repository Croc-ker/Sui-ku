using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mergeable : MonoBehaviour
{
    //this class handles what happens when shapes touch (send stuff to the GM) and control when they are dropped through inputs.
    [SerializeField] FloatVariable Timer;
    [SerializeField] FloatVariable Delay;

    public bool dropped;
    [SerializeField] public FloatVariable spawnXPos;
    [SerializeField] public Dropper dropper;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (dropped) return;

        transform.position = Vector2.Lerp(transform.position, new Vector2(spawnXPos, transform.position.y), .05f);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.gravityScale = 1;
            dropped = true;
            Dropper.shapesInPlayList.Add(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == collision.gameObject.tag)
        {
            if (!dropped) return;
            Debug.Log("ATTEMPTING MERGE");
            //dropper.addToMerges(gameObject);
            Dropper.shapeMergeList.Add(gameObject);
            Dropper.shapesInPlayList.Remove(gameObject);
        }
    }
}