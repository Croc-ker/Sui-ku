using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
	[SerializeField] FloatVariable Timer;
	bool check = false;

	void Update()
	{
		if (Time.time >= Timer)
		{
			//Debug.Log("Game Over");
		}

	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Finish"))
		{
			//Timer.value = Time.time + 3;
		}
	}
}
