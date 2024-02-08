using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    void Update()
    {
        //transform.Rotate(0, 0, speed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
        {
            float ranX = Random.Range(-speed, speed);
            float rany = Random.Range(-speed, speed);
            transform.Translate(ranX, rany, 0);
        }
    }
}
