using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private FloatVariable timer;
    [SerializeField] private BoolEvent loss;
    private bool check = false;

    void Start()
    {
        timer.value = 0;
    }

    private void Update()
    {
        if (check && Time.time >= timer)
        {
            loss?.RaiseEvent(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var sphere = collision.gameObject.GetComponent<Mergeable>();

        if (sphere.dropped)
        {
            timer.value = Time.time + 4;
            check = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        print("You Survive");
        check = false;
        timer.value = 0;
    }

    #region CoroutineTry
    //private float time = 4;
    //private bool check = false;

    //Coroutine timerCoroutine;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var sphere = collision.gameObject.GetComponent<Mergeable>();

    //    if (sphere.dropped)
    //    {
    //        check = true;
    //        timerCoroutine = StartCoroutine(Timer(time));
    //    }
    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    check = false;
    //}

    //IEnumerator Timer(float time)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(time);

    //        if (check) print("Game Over");
    //        else print("You survived");

    //        StopAllCoroutines();
    //    }
    //}
    #endregion

}
