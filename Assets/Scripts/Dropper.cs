using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] List<GameObject> Shapes = new List<GameObject>();
    public int maxIndex;
    private float timer = 0;
    public float dropDelay;
    public float maxDistance;
    private Vector2 range;
    public float speed;
    private bool shapeExists = false;
    public static Vector2 pos;
    private void Start()
    {
        range.x = -maxDistance + transform.position.x;
        range.y = maxDistance + transform.position.x;
    }
    private void Update()
    {
        pos = transform.position;
        if (Time.time >= timer && shapeExists)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shapeExists = false;
                timer = Time.time + dropDelay;
            }
        }
        else if(Time.time >= timer && !shapeExists) 
        {
            Instantiate(Shapes[Random.Range(0, maxIndex + 1)], transform.position, Quaternion.identity);
            shapeExists = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > range.x)
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < range.y)
        {
            transform.Translate(speed, 0, 0);
        }
    }
}
