using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    //this class will handle spawning shapes and moving the spawner.
    public static List<GameObject> shapeMergeList = new List<GameObject>();
    [SerializeField] FloatVariable Timer;
    [SerializeField] FloatVariable Delay;

    [Header("Shapes")]
    [SerializeField] List<GameObject> shapes = new List<GameObject>();
    [SerializeField, Range(0, 10)] int maxShapeSize;
    private bool holdingShape = false;

    [Header("Movement")]
    private Vector3 mousePosition;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] FloatVariable xPos;

    [Header("Misc.")]
    //x is min, y is max
    [SerializeField] Vector2 bounds = new Vector2();
    private void Start()
    {
        Timer.value = 0;
        bounds.x += transform.position.x;
        bounds.y += transform.position.x;
    }
    private void Update()
    {
        #region MOVEMENT
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.y = transform.position.y;
        mousePosition.x = Mathf.Clamp(mousePosition.x, bounds.x, bounds.y);
        //Debug.Log("Mouse x-axis: " + mousePosition.x.ToString());
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        xPos.value = transform.position.x;
        #endregion
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && holdingShape)
        {
            drop();
        }
        spawnShape();
        mergeShape();
    }
    private void spawnShape()
    {
        if (!holdingShape && Time.time >= Timer.value)
        {
            holdingShape = true;
            Vector2 spawn = new Vector2(xPos.value, transform.position.y - 1);
            Instantiate(shapes[Random.Range(0, maxShapeSize)], spawn, Quaternion.identity);
        }
    }

    public void mergeShape()
    {
        if (shapeMergeList.Count != 0)
        {
            //Instantiate(create());
            create();
            foreach (GameObject shape in shapeMergeList)
            {
                Destroy(shape);
            }
            Debug.Log("MERGE SUCCESS");

            shapeMergeList.Clear();
        }
    }

    public Mergeable create()
    {
        var shape1 = shapeMergeList[0];
        var shape2 = shapeMergeList[1];

        Vector2 avgPos = (shape1.transform.position + shape2.transform.position) / 2;
        int index = int.Parse(shape1.tag);
        GameObject shape = Instantiate(shapes[index], avgPos, Quaternion.identity);
        shape.GetComponent<Rigidbody2D>().gravityScale = 1;
        Mergeable mergeable = shape.GetComponent<Mergeable>();
        mergeable.dropped = true;
        mergeable.transform.position = avgPos;
        //mergeable.GetComponent<Rigidbody2D>().gravityScale = 1;
        return mergeable;
    }
    public void drop()
    {
        holdingShape = false;
        Timer.value = Time.time + Delay.value;
    }
}