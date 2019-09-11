using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	public bool isFalling = false;
	float speed = 5f;
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(isFalling == false)
		{
			Debug.Log("set it to true");
			isFalling = true;
		}
		else
		{
			Debug.Log("destroying");
			Destroy(gameObject);
		}
	}
	
	void FixedUpdate()
	{
		if(isFalling == true)
		{
			Vector2 newPos = gameObject.transform.position;
			newPos.y += 5;

			gameObject.transform.position = newPos;

		}
	}
}
